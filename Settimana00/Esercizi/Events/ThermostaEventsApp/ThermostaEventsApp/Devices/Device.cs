using ThermostaEventsApp.CoolingMechanisms;
using ThermostaEventsApp.Thermostats;

namespace ThermostaEventsApp.Devices
{
    public sealed class Device : IDevice
    {
        private const double WarningLevel = 27;
        private const double EmergencyLevel = 74;

        public double WarningTemperatureLevel => WarningLevel;
        public double EmergencyTemperatureLevel => EmergencyLevel;

        public void HandleEmergency()
        {
            Console.WriteLine();
            Console.WriteLine("Emergency handled! Sending out notifications to emergency services personal...");
            ShutdownDevice();
            Console.WriteLine();
        }

        private void ShutdownDevice()
        {
            Console.WriteLine("Shutting down the device...");
        }

        public void RunDevice()
        {
            Console.WriteLine("Device is running...");

            IHeatSensor heatSensor = HeatSensor.CreateInstance(WarningTemperatureLevel, EmergencyTemperatureLevel);
            var callback = new Action(heatSensor.DecreaseTemperature);
            ICoolingMechanism coolingMechanism = new CoolingMechanism(callback);
            IThermostat thermostat = new Thermostat(this, heatSensor, coolingMechanism);
            thermostat.RunThermostat();
        }
    }
}