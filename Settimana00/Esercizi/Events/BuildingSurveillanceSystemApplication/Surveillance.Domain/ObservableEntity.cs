using Surveillance.Domain.Interfaces;

namespace Surveillance.Domain
{
    public abstract class ObservableEntity : IObservableEntity
    {
        public EntityId Id { get; protected set; } = null!;
    }
}