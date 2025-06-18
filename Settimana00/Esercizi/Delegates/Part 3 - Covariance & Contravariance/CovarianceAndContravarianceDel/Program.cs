using System;

namespace CovarianceAndContravarianceDel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Covariance.Initialize();

            Console.ReadKey();
        }
    }

    public static class Covariance
    {
        delegate Car CarFactoryDel(int id, string name);

        public static void Initialize()
        {
            CarFactoryDel carFactoryDel = CarFactory.GetIceCar;
            Car iceCar = carFactoryDel(1, "Audi R8");

            Console.WriteLine($"Object type: {iceCar.GetType()}");
            Console.WriteLine(iceCar.GetCarDetails() + Environment.NewLine);

            carFactoryDel = CarFactory.GetEvCar;
            Car evCar = carFactoryDel(2, "Tesla Model-3");

            Console.WriteLine($"Object type: {evCar.GetType()}");
            Console.WriteLine(evCar.GetCarDetails());
        }
    }
}
