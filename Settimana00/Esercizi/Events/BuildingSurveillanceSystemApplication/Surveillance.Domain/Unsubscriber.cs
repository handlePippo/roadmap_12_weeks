namespace Surveillance.Domain
{
    public sealed class Unsubscriber<TEntity> : IDisposable
        where TEntity : ObservableEntity
    {
        private IObserver<TEntity>? _observer;
        private readonly IList<IObserver<TEntity>> _observers;
        private readonly object _gate;

        public Unsubscriber(IList<IObserver<TEntity>> observers, IObserver<TEntity> observer, object gate)
        {
            _observers = observers ?? throw new ArgumentNullException(nameof(observers));
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));
            _gate = gate ?? throw new ArgumentNullException(nameof(gate));
        }

        public void Dispose()
        {
            var observerSnapshot = _observer;
            if (observerSnapshot is null || _observer is null)
            {
                return;
            }

            lock (_gate)
            {
                if (_observer is null)
                {
                    return;
                }

                _observers.Remove(observerSnapshot);
                _observer = null;
            }
        }
    }
}