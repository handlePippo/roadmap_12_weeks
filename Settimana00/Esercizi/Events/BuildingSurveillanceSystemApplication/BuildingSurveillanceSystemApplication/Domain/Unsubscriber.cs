namespace BuildingSurveillanceSystemApplication.Domain
{
    public sealed class Unsubscriber<TSource> : IDisposable
        where TSource : class
    {
        private readonly List<IObserver<TSource>> _observers;
        private readonly IObserver<TSource> _observer;

        public Unsubscriber(List<IObserver<TSource>> observers, IObserver<TSource> observer)
        {
            _observers = observers;
            _observer = observer;
            Dispose();
        }

        public void Dispose()
        {
            _observers.Remove(_observer);
        }
    }
}
