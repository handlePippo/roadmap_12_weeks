using Surveillance.Application.Factories;
using Surveillance.Application.Interfaces;
using Surveillance.Contracts.DTOs;
using Surveillance.Domain;
using Surveillance.Infrastructure.Exstensions;

namespace Surveillance.Application
{
    public sealed class SecuritySurveillanceHub : IObservable<ExternalVisitor>, ISecuritySurveillanceHub
    {
        private readonly object _gate = new();
        private readonly IList<IObserver<ExternalVisitor>> _observers = [];
        private readonly IList<ExternalVisitor> _externalVisitors = [];
        private readonly IObservableApi<ExternalVisitor> _observableApi;

        public SecuritySurveillanceHub(IObservableApi<ExternalVisitor> observableApi)
        {
            _observableApi = observableApi;
        }

        IDisposable IObservable<ExternalVisitor>.Subscribe(IObserver<ExternalVisitor> observer)
        {
            ArgumentNullException.ThrowIfNull(observer);

            IObserver<ExternalVisitor>[] observersSnapshot;
            ExternalVisitor[] externalVisitorsSnapshot;

            lock (_gate)
            {
                _observers.TryAdd(observer);
                observersSnapshot = _observers.GetObserversSnapshot();
                externalVisitorsSnapshot = _externalVisitors.GetExternalVisitorsSnapshot();
            }

            _observableApi.NotifyObservers(externalVisitorsSnapshot, observersSnapshot);

            return new Unsubscriber<ExternalVisitor>(_observers, observer, _gate);
        }

        public void ConfirmExternalVisitorEntersBuilding(ExternalVisitorDto externalVisitorDto)
        {
            ArgumentNullException.ThrowIfNull(externalVisitorDto);

            IObserver<ExternalVisitor>[] observersSnapshot;
            ExternalVisitor[] externalVisitorsSnapshot;

            lock (_gate)
            {
                var externalVisitor = ExternalVisitorFactory.Map(externalVisitorDto);
                _externalVisitors.Add(externalVisitor);
                observersSnapshot = _observers.GetObserversSnapshot();
                externalVisitorsSnapshot = _externalVisitors.GetExternalVisitorsSnapshot();
            }

            _observableApi.NotifyObservers(externalVisitorsSnapshot, observersSnapshot);
        }

        public void ConfirmExternalVisitorExitsBuilding(EntityId externalVisitorId, DateTime exitDateTime)
        {
            ArgumentNullException.ThrowIfNull(externalVisitorId);

            IObserver<ExternalVisitor>[] observersSnapshot;
            ExternalVisitor[] externalVisitorsSnapshot;

            lock (_gate)
            {
                var externalVisitor = _externalVisitors.FirstOrDefault(e => e.Id == externalVisitorId);
                if (externalVisitor is null)
                {
                    return;
                }

                externalVisitor.SetExitDateTime(exitDateTime);

                observersSnapshot = _observers.GetObserversSnapshot();
                externalVisitorsSnapshot = _externalVisitors.GetExternalVisitorsSnapshot();
            }

            _observableApi.NotifyObservers(externalVisitorsSnapshot, observersSnapshot);
        }

        public void BuildingEntryCutOffTimeReached()
        {
            IObserver<ExternalVisitor>[] observersSnapshot;
            ExternalVisitor[] externalVisitorsSnapshot;

            lock (_gate)
            {
                observersSnapshot = _observers.GetObserversSnapshot();
                externalVisitorsSnapshot = _externalVisitors.GetExternalVisitorsSnapshot();
            }

            if (!externalVisitorsSnapshot.IsSomeoneInBuilding())
            {
                _observableApi.ReleaseAllObservers(observersSnapshot);
            }
        }
    }
}
