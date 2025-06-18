namespace CovarianceAndContravarianceDel
{
    public abstract class Car()
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual string GetCarDetails() => $"{Id} - {Name}";
    }

    public sealed class IceCar : Car
    {
        public override string GetCarDetails() => $"{base.GetCarDetails()} - Internal Combustion Engine";
    };

    public sealed class EvCar : Car
    {
        public override string GetCarDetails() => $"{base.GetCarDetails()} - Electric";
    }
}
