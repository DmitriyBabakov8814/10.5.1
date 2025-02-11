namespace task1
{

    public interface ISumm
    {
        double Summ(double x, double y);
    }

    public class Summ : ISumm
    {
        double ISumm.Summ(double x, double y)
        {
            double sum = x + y;
            return sum;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Введите число x");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите число y");
                double y = double.Parse(Console.ReadLine());
                ISumm summ = new Summ();

                Console.WriteLine($"Cумма {x} + {y} = " + summ.Summ(x, y));
            }

            catch(System.FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
