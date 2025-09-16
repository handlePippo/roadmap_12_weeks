using Surveillance.Domain.Interfaces;

namespace Surveillance.Domain.Entities.Base
{
    public abstract class ObserverEntity<TEntity> : EntityBase<TEntity>, IObserverEntity
        where TEntity : class
    {
        public string ObserverName { get; set; } = null!;
    }
}