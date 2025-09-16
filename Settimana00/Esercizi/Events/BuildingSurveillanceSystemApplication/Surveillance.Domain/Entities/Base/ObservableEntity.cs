using Surveillance.Domain.Interfaces;

namespace Surveillance.Domain.Entities.Base
{
    public abstract class ObservableEntity<TEntity> : EntityBase<TEntity>, IObservableEntity
        where TEntity : class
    {
        public string ObservervableName { get; set; } = null!;
    }
}