
using Surveillance.Domain;

namespace Surveillance.Infrastructure.Exstensions
{
    public static class Exstensions
    {
        public static void TryAdd<TEntity>(this IList<IObserver<TEntity>> sources, IObserver<TEntity> source)
            where TEntity : ObservableEntity
        {
            ArgumentNullException.ThrowIfNull(sources, nameof(sources));
            ArgumentNullException.ThrowIfNull(source, nameof(source));

            if (!sources.Contains(source))
            {
                sources.Add(source);
            }
        }

        public static bool IsSomeoneInBuilding(this IEnumerable<ExternalVisitor> externalVisitors)
        {
            ArgumentNullException.ThrowIfNull(nameof(externalVisitors));

            return externalVisitors.Any(e => e.InBuilding);
        }

        public static IObserver<ExternalVisitor>[] GetObserversSnapshot(this IEnumerable<IObserver<ExternalVisitor>> observers)
            => observers?.ToArray() ?? throw new ArgumentNullException(nameof(observers));

        public static ExternalVisitor[] GetExternalVisitorsSnapshot(this IEnumerable<ExternalVisitor> externalVisitors)
            => externalVisitors?.ToArray() ?? throw new ArgumentNullException(nameof(externalVisitors));
    }
}