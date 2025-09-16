using Surveillance.Application.Interfaces;
using Surveillance.Domain.Entities.Base;

namespace Surveillance.Infrastructure.APIs
{
    /// <summary>
    /// Observer API
    /// </summary>
    public sealed class ObserverApi<TEntity> : IObservableApi<TEntity>
        where TEntity : ObservableEntity<TEntity>
    {
        /// <summary>
        /// Notifies the observers tied to a particular external visitor.
        /// </summary>
        /// <param name="observedEntities"></param>
        /// <param name="observers"></param>
        void IObservableApi<TEntity>.NotifyObservers(IReadOnlyList<TEntity> observedEntities, IReadOnlyList<IObserver<TEntity>> observers)
        {
            ArgumentNullException.ThrowIfNull(observedEntities);
            ArgumentNullException.ThrowIfNull(observers);

            foreach (var entity in observedEntities)
            {
                foreach (IObserver<TEntity> observer in observers)
                {
                    try
                    {
                        observer.OnNext(entity);
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        LogError($"Observer threw: {ex}");
                    }
                }
            }
        }

        /// <summary>
        /// Notifies the observers that the job is done.
        /// </summary>
        /// <param name="observers"></param>
        void IObservableApi<TEntity>.ReleaseAllObservers(IReadOnlyList<IObserver<TEntity>> observers)
        {
            ArgumentNullException.ThrowIfNull(observers);

            foreach (IObserver<TEntity> observer in observers)
            {
                try
                {
                    observer.OnCompleted();
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                    LogError($"Observer threw: {ex}");
                }
            }
        }

        private static void LogError(string message) => Console.Error.WriteLine(message);
    }
}
