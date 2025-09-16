namespace Surveillance.Domain.Various
{
    public sealed class DisposableAction : IDisposable
    {
        private Action _action;
        public DisposableAction(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void Dispose()
        {
            var action = Interlocked.Exchange(ref _action!, null);
            action?.Invoke();
        }
    }
}