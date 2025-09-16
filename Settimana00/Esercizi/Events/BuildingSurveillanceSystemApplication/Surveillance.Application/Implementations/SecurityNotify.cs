using Surveillance.Domain.Entities;

namespace Surveillance.Application.Implementations
{
    public sealed record SecurityNotify : IObserver<ExternalVisitor>
    {
        public SecurityNotify() { }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ExternalVisitor value)
        {
            throw new NotImplementedException();
        }
    }
}