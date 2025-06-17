namespace DelegateBasicExample
{
    internal class Program
    {
        delegate void LogDelegate(string text);
        static void Main(string[] args)
        {
            Log log = new Log();
            LogDelegate consoleDel = new LogDelegate(log.LogTextToScreen);
            LogDelegate fileDel = new LogDelegate(log.LogTextToFile);

            // Multi-cast delegate
            LogDelegate LogTextToScreenDelegate, LogTextToFileDelegate;
            LogTextToScreenDelegate = new LogDelegate(log.LogTextToScreen);
            LogTextToFileDelegate = new LogDelegate(log.LogTextToFile);
            LogDelegate multiCastDelegate = LogTextToScreenDelegate + LogTextToFileDelegate;

            Console.WriteLine("Please enter your name");

            string? name = Console.ReadLine();
            //consoleDel(name!);
            //fileDel(name!);

            // Multi-cast delegate
            //multiCastDelegate(name!); // directly invoking
            LogText(multiCastDelegate, name!); // passing the delegate as parameter to a method


            Console.ReadKey();
        }

        static void LogText(LogDelegate action, string text)
        {
            action(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (var sw = new StreamWriter(path: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), append: true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
