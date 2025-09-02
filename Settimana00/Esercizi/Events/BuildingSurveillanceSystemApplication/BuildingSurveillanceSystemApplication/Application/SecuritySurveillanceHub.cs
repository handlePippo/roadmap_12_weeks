using BuildingSurveillanceSystemApplication.Domain;
using BuildingSurveillanceSystemApplication.Dto;

namespace BuildingSurveillanceSystemApplication.Application
{

    public sealed class Unsubscriber<ExternalVisitor> : IDisposable
    {
        private readonly List<IObserver<ExternalVisitor>> _observers;
        private readonly IObserver<ExternalVisitor> _observer;
        private readonly object _gate; // stesso oggetto usato dal publisher

        public Unsubscriber(List<IObserver<ExternalVisitor>> observers, IObserver<ExternalVisitor> observer, object gate)
        {
            _observers = observers;
            _observer = observer;
            _gate = gate;
        }

        public void Dispose()
        {
            lock (_gate)
            {
                if (_observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }

    public sealed class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {
        private readonly List<ExternalVisitor> _externalVisitors = [];
        private readonly List<IObserver<ExternalVisitor>> _observers = [];
        private readonly object _gate = new(); // GATE CONDIVISO

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {
            ExternalVisitor[] externalVisitorsSnapshot;
            
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            foreach (ExternalVisitor externalVisitor in _externalVisitors)
            {
                ObserverApi.NotifyObservers(externalVisitor, _observers);
            }

            throw new NotImplementedException();


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
            var externalVisitor = _externalVisitors.FirstOrDefault(e => e.Id == externalVisitorEntityId);

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
                ObserverApi.ReleaseObservers(_observers);
            }
        }
    }

    /// <summary>
    /// Observer API
    /// </summary>
    public static class ObserverApi
    {
        /// <summary>
        /// Notifies the observers tied to a particular external visitor.
        /// </summary>
        /// <param name="externalVisitor"></param>
        /// <param name="observers"></param>
        public static void NotifyObservers(ExternalVisitor externalVisitor, IReadOnlyList<IObserver<ExternalVisitor>> observers)
        {
            ArgumentNullException.ThrowIfNull(externalVisitor);
            ArgumentNullException.ThrowIfNull(observers);

            foreach (IObserver<ExternalVisitor> observer in observers)
            {
                observer.OnNext(externalVisitor);
            }
        }

        /// <summary>
        /// Notifies the observers that the job is done.
        /// </summary>
        /// <param name="observers"></param>
        public static void ReleaseObservers(IReadOnlyList<IObserver<ExternalVisitor>> observers)
        {
            ArgumentNullException.ThrowIfNull(observers);

            foreach (IObserver<ExternalVisitor> observer in observers)
            {
                observer.OnCompleted();
            }
        }
    }
}
