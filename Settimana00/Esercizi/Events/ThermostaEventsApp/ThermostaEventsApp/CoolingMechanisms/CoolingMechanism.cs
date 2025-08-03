namespace ThermostaEventsApp.CoolingMechanisms
{
    public sealed class CoolingMechanism : ICoolingMechanism
    {
        private static Action _decreaseTemperatureCallback = null!;
        private const int MaxTemperatureDecreasing = 3;
        private int _maxTemperatureDecreasingCounter = 0;
        public CoolingMechanism(Action decreaseTemperatureCallback)
        {
            _decreaseTemperatureCallback = decreaseTemperatureCallback;
        }

        public void Off()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism OFF..");
            Console.WriteLine();
        }

        public void On()
        {
            Console.WriteLine();
            if (_maxTemperatureDecreasingCounter < MaxTemperatureDecreasing)
            {
                Console.WriteLine("Switching cooling mechanism ON..");
                _decreaseTemperatureCallback();
                _maxTemperatureDecreasingCounter++;
            }
            else if(_maxTemperatureDecreasingCounter == MaxTemperatureDecreasing)
            {
                Console.WriteLine("Switching cooling mechanism ON..");
                Console.WriteLine("Cooling mechanism does not works anymore!");
                _maxTemperatureDecreasingCounter++;
            }
            Console.WriteLine();
        }
    }
}