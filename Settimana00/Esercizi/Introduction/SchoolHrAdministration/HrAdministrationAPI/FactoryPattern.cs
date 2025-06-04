namespace HrAdministrationAPI
{
    public static class FactoryPattern<TSource, TDestination>
        where TDestination : class, TSource, new()
    {
        public static TSource GetInstance()
        {
            TSource obj;
            obj = new TDestination();
            return obj;
        }
    }
}