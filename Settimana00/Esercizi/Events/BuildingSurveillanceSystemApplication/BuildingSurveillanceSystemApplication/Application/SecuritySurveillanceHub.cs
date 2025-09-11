using BuildingSurveillanceSystemApplication.Domain;
using BuildingSurveillanceSystemApplication.Dto;
using BuildingSurveillanceSystemApplication.Infrastructure;

namespace BuildingSurveillanceSystemApplication.Application
{
    public sealed class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {
        private readonly List<IObserver<ExternalVisitor>> _observers = [];
        private readonly List<ExternalVisitor> _externalVisitors = [];
        private ExternalVisitor? this[EntityId id] => _externalVisitors.FirstOrDefault(e => e.Id == id);

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {
            _observers.TryAdd(observer);
            foreach (ExternalVisitor externalVisitor in _externalVisitors)
            {
                ObserverApi.NotifyObservers(externalVisitor, _observers);
            }

            return new Unsubscriber<ExternalVisitor>(_observers, observer);
        }


        public void ConfirmExternalVisitorEntersBuilding(ExternalVisitorDto externalVisitorDto)
        {
            ExternalVisitor externalVisitor = externalVisitorDto;

            _externalVisitors.Add(externalVisitor);

            ObserverApi.NotifyObservers(externalVisitor, _observers);
        }

        public void ConfirmExternalVisitorExitsBuilding(string externalVisitorId, DateTime exitDateTime)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(externalVisitorId);

            var externalVisitorEntityId = EntityId.Create(externalVisitorId);
            var externalVisitor = this[externalVisitorEntityId];

            if (externalVisitor is not null)
            {
                externalVisitor.SetExitDateTime(exitDateTime);
                ObserverApi.NotifyObservers(externalVisitor, _observers);
            }
        }

        public void BuildingEntryCutOffTimeReached()
        {
            if (!_externalVisitors.Any(e => e.InBuilding))
            {
                ObserverApi.ReleaseAllObservers(_observers);
            }
        }
    }
}
