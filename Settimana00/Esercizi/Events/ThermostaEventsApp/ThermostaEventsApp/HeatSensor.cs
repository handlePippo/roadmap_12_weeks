using System.ComponentModel;
using ThermostaEventsApp;

public class HeatSensor : IHeatSensor
{
    private static double _warningLevel = default;
    private static double _emergencyLevel = default;
    private static bool _hasReachedWarningTemperature = default;
    private static double[] _temperatureData = default!;

    public double this[double temperature]
    {
        get
        {
            return _temperatureData.FirstOrDefault(t => t == temperature);
        }
    }

    private static readonly object _temperatureReachesWarningLevelKey = new();
    private static readonly object _temperatureReachesEmergencyLevelKey = new();
    private static readonly object _temperatureFallsBelowWarningLevelKey = new();
    private static readonly object _lockObj = new();

    private static readonly EventHandlerList _listEventDelegates = new EventHandlerList();

    private static HeatSensor _instance = null!;
    private HeatSensor(double wLevel, double eLevel)
    {
        _warningLevel = wLevel;
        _emergencyLevel = eLevel;

        SeedData();
    }

    public static HeatSensor CreateInstance(double wLevel, double eLevel)
    {
        lock (_lockObj)
        {
            _instance ??= new HeatSensor(wLevel, eLevel);
            return _instance;
        }
    }

    protected void OnTemperatureReachedEmergencyLevel(TemperatureEventArgs e)
    {
        GetProperHandler(_temperatureReachesEmergencyLevelKey)?.Invoke(this, e);
    }

    protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
    {
        GetProperHandler(_temperatureReachesWarningLevelKey)?.Invoke(this, e);
    }

    protected void OnTemperatureFallsBelowWarningLevel(TemperatureEventArgs e)
    {
        GetProperHandler(_temperatureFallsBelowWarningLevelKey)?.Invoke(this, e);
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
    {

        add
        {
            _listEventDelegates.AddHandler(_temperatureReachesEmergencyLevelKey, value);
        }

        remove
        {
            _listEventDelegates.RemoveHandler(_temperatureReachesEmergencyLevelKey, value);
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
    {
        add
        {
            _listEventDelegates.AddHandler(_temperatureReachesWarningLevelKey, value);
        }

        remove
        {
            _listEventDelegates.RemoveHandler(_temperatureReachesWarningLevelKey, value);
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallsBelowWarningLevelEventHandler
    {
        add
        {
            _listEventDelegates.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
        }

        remove
        {
            _listEventDelegates.RemoveHandler(_temperatureFallsBelowWarningLevelKey, value);
        }
    }

    public void RunHeatSensor()
    {
        Console.WriteLine("Heat sensor is running...");
        MonitorTemperature();
    }

    private void MonitorTemperature()
    {
        foreach(double temperature in _temperatureData)
        {
            Console.ResetColor();
            Console.WriteLine($"DateTime: {DateTime.Now} - Temperature: {temperature}");

            if(temperature >= _emergencyLevel)
            {
                TemperatureEventArgs e = new TemperatureEventArgs
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureReachedEmergencyLevel(e);
            }
            else if(temperature >= _warningLevel)
            {
                _hasReachedWarningTemperature = true;
                TemperatureEventArgs e = new TemperatureEventArgs
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureFallsBelowWarningLevel(e);
            }
            else if(temperature < _warningLevel && _hasReachedWarningTemperature)
            {
                TemperatureEventArgs e = new TemperatureEventArgs
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureFallsBelowWarningLevel(e);
            }

            Thread.Sleep(1000);
        }
    }

    private void SeedData()
    {
        _temperatureData = new double[]
        {
            16,17,16.5,18,19,22,24,25.75,28.60,27.90,31,24.30,45,68,86.29
        };
    }

    private static EventHandler<TemperatureEventArgs>? GetProperHandler(object key) => _listEventDelegates[key] as EventHandler<TemperatureEventArgs>;
}