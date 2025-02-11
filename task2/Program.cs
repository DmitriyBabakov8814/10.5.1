namespace task2
{
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        void ILogger.Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[Event] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        void ILogger.Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Error] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public interface ISumm
    {
        double Summ(double x, double y);
    }

    public class Summ : ISumm
    {
        ILogger Logger { get; }
        public Summ(ILogger logger)
        {
            Logger = logger;
        }
        double ISumm.Summ(double x, double y)
        {
            Logger.Event("Калькулятор начал свою работу");
            double sum = x + y;
            Logger.Event("Калькулятор успешно закончил свою работу");
            return sum;
        }
    }

    internal class Program
    {
        static ILogger logger { get; set; }
        static void Main(string[] args)
        {
            logger = new Logger();
            try
            {
                Console.WriteLine("Введите число x");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите число y");
                double y = double.Parse(Console.ReadLine());
                ISumm summ = new Summ(logger);
                Console.WriteLine($"Cумма {x} + {y} = " + summ.Summ(x, y));
            }
            catch (System.FormatException ex)
            {
                logger.Error("Произошла ошибка System.FormatException, неверно введено значение x или y");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
