using System.ComponentModel;

namespace ThermostaEventsApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
        }
    }
}

public interface IHeatSensor
{
    event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;
    event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;
    event EventHandler<TemperatureEventArgs> TemperatureFallsBelowWarningLevelEventHandler;
    void RunHeatSensor();
}

public class HeatSensor : IHeatSensor
{
    private static double _warningLevel = default;
    private static double _emergencyLevel = default;
    private static bool _hasReachedWarningTemperature = default;
    private static double[] _temperatureData = default!;

    public double this[int temperature]
    {
        get
        {
            return _temperatureData.Where(t => t == temperature).FirstOrDefault();
        }
    }

    private static readonly object _temperatureReachesWarningLevelKey = new();
    private static readonly object _temperatureReachesEmergencyLevelKey = new();
    private static readonly object _temperatureFallsBelowWarningLevelKey = new();
    private static readonly object _lockObj = new();

    protected static EventHandlerList listEventDelegates = new EventHandlerList();

    private static HeatSensor _instance = null!;
    private HeatSensor(double wLevel, double eLevel)
    {
        _warningLevel = wLevel;
        _emergencyLevel = eLevel;

        SeedData();
    }

    private void SeedData()
    {
        _temperatureData = new double[]
        {
            16,17,16.5,18,19,22,24,25.75,28.60,27.90,31,24.30,45,68,86.29
        };
    }

    public static HeatSensor CreateInstance(double wLevel, double eLevel)
    {
        lock (_lockObj)
        {
            _instance ??= new HeatSensor(wLevel, eLevel);
            return _instance;
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
    {

        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallsBelowWarningLevelEventHandler
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    public void RunHeatSensor()
    {
        throw new NotImplementedException();
    }
}