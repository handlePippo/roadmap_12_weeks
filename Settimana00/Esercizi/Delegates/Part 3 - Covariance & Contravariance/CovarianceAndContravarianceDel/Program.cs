namespace CovarianceAndContravarianceDel
{
    delegate Car CarFactoryDel(int id, string name);
    delegate void LogIceCarDetailsDelegate(IceCar iceCa);
    delegate void LogEvCarDetailsDelegate(EvCar evCar);

    internal class Program
    {
        static void Main(string[] args)
        {
            Covariance.Initialize();
            Contravariance.Initialize();
            Console.ReadKey();
        }
    }

    public static class Contravariance
    {
        public static void Initialize()
        {
            Console.WriteLine("Contravariance" + Environment.NewLine);

            LogIceCarDetailsDelegate logIceCarDetailsDelegate = LogCarDetails;
            LogEvCarDetailsDelegate logEvCarDetailsDelegate = LogCarDetails;

            CarFactoryDel carFactoryDel = CarFactory.GetIceCar;
            CarFactoryDel evFactoryDel = CarFactory.GetEvCar;

            Car iceCar = carFactoryDel(1, "Volvo V40");
            Car evCar = evFactoryDel(2, "Toyota Hybrid");

            logIceCarDetailsDelegate((IceCar)iceCar);
            logEvCarDetailsDelegate((EvCar)evCar);
        }

        static void LogCarDetails(Car car)
        {
            if (car is IceCar iceCar)
            {
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IceDetails.txt"), true))
                {
                    sw.WriteLine($"Object type: {iceCar.GetType()}");
                    sw.WriteLine(iceCar.GetCarDetails() + Environment.NewLine);
                }
                return;
            }
            else if (car is EvCar evCar)
            {
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EvDetails.txt"), true))
                {
                    sw.WriteLine($"Object type: {evCar.GetType()}");
                    sw.WriteLine(evCar.GetCarDetails() + Environment.NewLine);
                }
                return;
            }
            throw new ArgumentException();
        }
    }

    public static class Covariance
    {
        public static void Initialize()
        {
            Console.WriteLine("Covariance" + Environment.NewLine);
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
