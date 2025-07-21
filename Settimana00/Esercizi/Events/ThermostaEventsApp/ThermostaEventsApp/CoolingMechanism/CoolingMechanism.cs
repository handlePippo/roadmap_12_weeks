public class CoolingMechanism : ICoolingMechanism
{
    public void Off()
    {
        Console.WriteLine();
        Console.WriteLine("Switching cooling mechanism OFF..");
        Console.WriteLine();
    }

    public void On()
    {
        Console.WriteLine();
        Console.WriteLine("Switching cooling mechanism ON..");
        Console.WriteLine();
    }
}