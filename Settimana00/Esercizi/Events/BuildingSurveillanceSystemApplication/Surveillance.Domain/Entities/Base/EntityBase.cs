using Surveillance.Domain.Interfaces;
using Surveillance.Domain.Various;

namespace Surveillance.Domain.Entities.Base
{
    public abstract class EntityBase<TEntity> : IEntityBase
        where TEntity : class
    {
        public EntityId Id { get; protected set; } = null!;
    }
}