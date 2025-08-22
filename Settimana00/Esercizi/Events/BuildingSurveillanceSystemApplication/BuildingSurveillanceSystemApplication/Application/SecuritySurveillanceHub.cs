using BuildingSurveillanceSystemApplication.Domain;
using BuildingSurveillanceSystemApplication.Dto;

namespace BuildingSurveillanceSystemApplication.Application
{
    public sealed class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {
        private readonly List<ExternalVisitor> _externalVisitors = [];
        private readonly List<IObserver<ExternalVisitor>> _observers = [];

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {
            if(!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            foreach(ExternalVisitor externalVisitor in _externalVisitors)
            {
                observer.OnNext(externalVisitor);
            }

            throw new NotImplementedException();
        }

        public void ConfirmExternalVisitorEntersBuilding(ExternalVisitorDto externalVisitorDto)
        {
            ExternalVisitor externalVisitor = externalVisitorDto;

            _externalVisitors.Add(externalVisitor);

            NotifyObservers(externalVisitor);
        }

        public void ConfirmExternalVisitorExitsBuilding(string externalVisitorId, DateTime exitDateTime)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(externalVisitorId);

            var externalVisitor = _externalVisitors.FirstOrDefault(e => e.Id == EntityId.Create(externalVisitorId));

            if (externalVisitor is not null)
            {
                externalVisitor.SetExitDateTime(exitDateTime);
                NotifyObservers(externalVisitor);
            }
        }

        public void BuildingEntryCutOffTimeReached()
        {
            if (!_externalVisitors.Any(e => e.InBuilding))
            {
                Complete();
            }
        }

        private void NotifyObservers(ExternalVisitor externalVisitor)
        {
            foreach (IObserver<ExternalVisitor> observer in _observers)
            {
                observer.OnNext(externalVisitor);
            }
        }

        private void Complete()
        {
            foreach (IObserver<ExternalVisitor> observer in _observers)
            {
                observer.OnCompleted();
            }
        }
    }
}
