using ThermostaEventsApp;

namespace ThermostaEventsApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
        }
    }
}

public interface IDevice
{
    void RunDevice();
    void HandleEmergency();
}
public interface IThermostat
{
    void RunThermostat();
}

public class Thermostat : IThermostat
{
    private readonly ICoolingMechanism _coolingMechanism = null!;
    private readonly IHeatSensor _heatSensor = null!;
    private readonly IDevice _device = null!;

    private const double WarningLevel = 27;
    private const double EmergencyLevel = 75;

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

    private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void HeatSensor_TemperatureFallsBelowWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        throw new NotImplementedException();
    }

    public void RunThermostat()
    {
        throw new NotImplementedException();
    }
}

public interface ICoolingMechanism
{
    void On();
    void Off();
}

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