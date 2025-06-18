namespace CovarianceAndContravarianceDel
{
    public static class CarFactory
    {
        public static IceCar GetIceCar(int id, string name) => new IceCar { Id = id, Name = name };
        public static EvCar GetEvCar(int id, string name) => new EvCar { Id = id, Name = name };
    }
}
