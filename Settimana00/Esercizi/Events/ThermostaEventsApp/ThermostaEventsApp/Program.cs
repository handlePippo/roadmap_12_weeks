using ThermostaEventsApp.Devices;

namespace ThermostaEventsApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            new Device().RunDevice();
        }
    }
}