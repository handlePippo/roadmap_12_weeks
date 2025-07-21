namespace ThermostaEventsApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            IDevice device = new Device();
            ICoolingMechanism coolingMechanism = new CoolingMechanism();
            IHeatSensor heatSensor = HeatSensor.CreateInstance(20, 75);

            IThermostat thermostat = new Thermostat(device, heatSensor, coolingMechanism);

            thermostat.RunThermostat();
        }
    }
}