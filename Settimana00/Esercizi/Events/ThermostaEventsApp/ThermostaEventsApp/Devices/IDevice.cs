namespace ThermostaEventsApp.Devices
{
    public interface IDevice
    {
        double WarningTemperatureLevel { get; }
        double EmergencyTemperatureLevel { get; }
        void RunDevice();
        void HandleEmergency();
    }
}