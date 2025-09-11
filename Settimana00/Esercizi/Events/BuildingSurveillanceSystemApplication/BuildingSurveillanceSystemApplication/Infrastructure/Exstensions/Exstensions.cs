using BuildingSurveillanceSystemApplication.Domain;

namespace BuildingSurveillanceSystemApplication.Application
{
    public static class Exstensions
    {
        public static void TryAdd(this List<IObserver<ExternalVisitor>> sources, IObserver<ExternalVisitor> source)
        {
            if (!sources.Contains(source))
            {
                sources.Add(source);
            }
        }
    }
}
