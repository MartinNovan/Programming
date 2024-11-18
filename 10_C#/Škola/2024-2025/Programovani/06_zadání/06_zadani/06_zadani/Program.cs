namespace _06_zadani;

internal abstract class Program
{
    private static void Main()
    {
        Console.WriteLine("Zadejte počáteční hodnotu");
        double a = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.WriteLine("Zadejte krok.");
        double krok = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        
        if (Math.Abs(krok) >= 1)
        {
            Console.WriteLine("Krok musí být menší než 1!");
            return;
        }
        
        Console.WriteLine("Zadejte počet opakování");
        int pocet = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        double[] posloupnost = new double[pocet];
        posloupnost[0] = a;
        
        for (int i = 1; i < pocet; i++)
        {
            posloupnost[i] = posloupnost[i - 1] * krok;
        }
        
        Console.WriteLine("\nPrvky geometrické posloupnosti:");
        for (int i = 0; i < pocet; i++)
        {
            Console.WriteLine($"a{i + 1} = {posloupnost[i]}");
        }

        double soucet = 0;
        for (int i = 0; i < pocet; i++)
        {
            soucet += posloupnost[i];
        }
        Console.WriteLine($"\nSoučet prvků geometrické řady je: {soucet}");
        
        if (pocet >= 5)
        {
            double soucetPrvniPaty = posloupnost[0] + posloupnost[4];
            Console.WriteLine($"Součet prvního a pátého prvku je: {soucetPrvniPaty}");
        }
    }
}
