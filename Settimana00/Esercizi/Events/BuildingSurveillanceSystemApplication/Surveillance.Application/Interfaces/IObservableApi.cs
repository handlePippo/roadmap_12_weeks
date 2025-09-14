using Surveillance.Domain.Interfaces;

namespace Surveillance.Application.Interfaces
{
    /// <summary>
    /// Contract for ObserableApi.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IObservableApi<TEntity> where TEntity : IObservableEntity
    {
        /// <summary>
        /// NotifyObservers
        /// </summary>
        /// <param name="observedEntities"></param>
        /// <param name="observers"></param>
        void NotifyObservers(IReadOnlyList<TEntity> observedEntities, IReadOnlyList<IObserver<TEntity>> observers);

        /// <summary>
        /// ReleaseAllObservers
        /// </summary>
        /// <param name="observers"></param>
        void ReleaseAllObservers(IReadOnlyList<IObserver<TEntity>> observers);
    }
}