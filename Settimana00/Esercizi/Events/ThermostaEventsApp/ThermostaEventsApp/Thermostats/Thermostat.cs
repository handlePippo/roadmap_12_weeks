using ThermostaEventsApp.CoolingMechanisms;
using ThermostaEventsApp.Devices;
using ThermostaEventsApp.Models;
using ThermostaEventsApp.Thermostats;

public class Thermostat : IThermostat
{
    private readonly ICoolingMechanism _coolingMechanism = null!;
    private readonly IHeatSensor _heatSensor = null!;
    private readonly IDevice _device = null!;

    public Thermostat(IDevice device, IHeatSensor heatSensor, ICoolingMechanism coolingMechanism)
    {
        _device = device;
        _heatSensor = heatSensor;
        _coolingMechanism = coolingMechanism;
    }

    private void WireUpEventsToEventHandlers()
    {
        _heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
        _heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
        _heatSensor.TemperatureFallsBelowWarningLevelEventHandler += HeatSensor_TemperatureFallsBelowWarningLevelEventHandler;
    }

    private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Critical alert!");
        Console.WriteLine($"Temperature level is {_device.EmergencyTemperatureLevel} and above. - Current temperature: {e.Temperature} ");
        _device.HandleEmergency();
        Console.ResetColor();
    }

    private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Warning alert!");
        Console.WriteLine($"Temperature level is between {_device.WarningTemperatureLevel} and {_device.EmergencyTemperatureLevel} - Current temperature: {e.Temperature} ");
        _coolingMechanism.On();
        Console.ResetColor();
    }

    private void HeatSensor_TemperatureFallsBelowWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Informartion alert!");
        Console.WriteLine($"Temperature falls below warning level. (Warning level is {_device.WarningTemperatureLevel} degrees and above) - Current temperature: {e.Temperature}");
        _coolingMechanism.Off();
        Console.ResetColor();
    }

    public void RunThermostat()
    {
        Console.ResetColor();
        Console.WriteLine("Thermostat is running...");
        WireUpEventsToEventHandlers();
        _heatSensor.RunHeatSensor();
    }
}