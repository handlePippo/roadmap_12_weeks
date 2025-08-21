using BuildingSurveillanceSystemApplication.Domain;
using BuildingSurveillanceSystemApplication.Dto;

namespace BuildingSurveillanceSystemApplication.Application
{
    public sealed class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {
        private readonly IList<ExternalVisitor> _externalVisitors = Array.Empty<ExternalVisitor>();
        private readonly IList<IObserver<ExternalVisitor>> _observers = Array.Empty<IObserver<ExternalVisitor>>();

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {
            _observers.Add(observer);
        
            throw new NotImplementedException();
        }

        public void ConfirmExternalVisitorEntersBuilding(ExternalVisitorDto externalVisitorDto)
        {
            ExternalVisitor externalVisitor = externalVisitorDto;
            _externalVisitors.Add(externalVisitor);

            foreach(IObserver<ExternalVisitor> observer in _observers)
            {
                observer.OnNext(externalVisitor);
            }


        }
    }
}