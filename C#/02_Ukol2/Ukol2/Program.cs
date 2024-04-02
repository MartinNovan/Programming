namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cisla;

            while (true)
            {
                Console.WriteLine("Zadej sekvenci čísel oddělených čárkou:");
                string vstup = Console.ReadLine();

                try
                {
                    cisla = vstup.Split(',').Select(int.Parse).ToArray();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Chybný formát vstupu. Zadej čísla znovu.");
                }
            }

            int min = cisla.Min();
            int max = cisla.Max();
            int nejdelsiVzestupnyInterval = vzestupnyinterval(cisla);

            Console.WriteLine($"Nejmenší číslo je {min}.");
            Console.WriteLine($"Největší číslo je {max}.");
            Console.WriteLine($"Délka nejdelšího vzestupného intervalu je {nejdelsiVzestupnyInterval}.");
        }

        static int vzestupnyinterval(int[] cisla)
        {
            int maxdelka = 0;
            int momentalnidelka = 1;

            for (int i = 1; i < cisla.Length; i++)
            {
                if (cisla[i] > cisla[i - 1])
                {
                    momentalnidelka++;
                }
                else
                {
                    maxdelka = Math.Max(maxdelka, momentalnidelka);
                    momentalnidelka = 1;
                }
            }

            maxdelka = Math.Max(maxdelka, momentalnidelka);

            return maxdelka;
        }
    }
}
