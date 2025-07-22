using ThermostaEventsApp.Devices;

namespace ThermostaEventsApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            IDevice device = new Device();
            device.RunDevice();
        }
    }
}