using static System.Net.Mime.MediaTypeNames;

namespace zadání
{
    internal class Program
    {
        static void Main()
        {
            double a = 0;
            double t = 0;
            double S = 0;
            Console.WriteLine("vybert hodnotu co chcete vypočítat:\n1.S\n2.a\n3.t");
            double VypoctovaHodnota = double.Parse(Console.ReadLine());
            if (VypoctovaHodnota == 1)
            {
                Console.WriteLine("Zadejte hondotu a");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("zadejte hodnotu t");
                t = double.Parse(Console.ReadLine());
                S = (a * Math.Pow(t, 2)) / 2;
                Console.WriteLine($"S = {S}");
                Restart();
            }
            else if (VypoctovaHodnota == 2)
            {
                Console.WriteLine("Zadejte hondotu S");
                S = double.Parse(Console.ReadLine());
                Console.WriteLine("zadejte hodnotu t");
                t = double.Parse(Console.ReadLine());
                if(t <= 0)
                {
                    Console.WriteLine("'t' nemůže být nula či méně");
                    Restart();
                }
                a = (2 * S) / Math.Pow(t, 2);
                Console.WriteLine($"a = {a}");
                Restart();
            }
            else if (VypoctovaHodnota == 3)
            {
                Console.WriteLine("Zadejte hondotu S");
                S = double.Parse(Console.ReadLine());
                if (S < 0)
                {
                    Console.WriteLine("'S' nemůže být negativní");
                    Restart();
                }
                Console.WriteLine("zadejte hodnotu a");
                a = double.Parse(Console.ReadLine());
                if (a <= 0)
                {
                    Console.WriteLine("'a' nemůže být nula či méně");
                    Restart();
                }
                t = Math.Sqrt((2*S)/a);
                Console.WriteLine($"t = {t}");
                Restart();
            }
            else
            {
                Console.WriteLine("Špatná hodnota");
                Restart();
            }
        }
        static void Restart()
        {
            Console.WriteLine("Chcete zopakovat? Y/N (default:N)");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                Console.Clear();
                Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
