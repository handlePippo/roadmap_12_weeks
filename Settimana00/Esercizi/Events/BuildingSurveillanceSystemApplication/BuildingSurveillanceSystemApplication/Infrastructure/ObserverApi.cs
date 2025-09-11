using BuildingSurveillanceSystemApplication.Domain;

namespace BuildingSurveillanceSystemApplication.Infrastructure
{
    /// <summary>
    /// Observer API
    /// </summary>
    public static class ObserverApi
    {
        /// <summary>
        /// Notifies the observers tied to a particular external visitor.
        /// </summary>
        /// <param name="externalVisitor"></param>
        /// <param name="observers"></param>
        public static void NotifyObservers(ExternalVisitor externalVisitor, IReadOnlyList<IObserver<ExternalVisitor>> observers)
        {
            ArgumentNullException.ThrowIfNull(externalVisitor);
            ArgumentNullException.ThrowIfNull(observers);

            foreach (IObserver<ExternalVisitor> observer in observers)
            {
                observer.OnNext(externalVisitor);
            }
        }

        /// <summary>
        /// Notifies the observers that the job is done.
        /// </summary>
        /// <param name="observers"></param>
        public static void ReleaseAllObservers(IReadOnlyList<IObserver<ExternalVisitor>> observers)
        {
            ArgumentNullException.ThrowIfNull(observers);

            foreach (IObserver<ExternalVisitor> observer in observers)
            {
                observer.OnCompleted();
            }
        }
    }
}
