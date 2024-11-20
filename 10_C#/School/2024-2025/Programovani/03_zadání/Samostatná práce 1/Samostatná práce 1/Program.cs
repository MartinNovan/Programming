internal class Program
{
    private static void Main(string[] args)
    {
        //zadání hodnot
        Console.WriteLine("Zadejte výšku kuželu:");
        int vyska = int.Parse(Console.ReadLine());
        Console.WriteLine("Zadejte poloměr podstavy:");
        int polomer = int.Parse(Console.ReadLine());

        //výpočet
        double povrch = (Math.PI * Math.Pow(polomer,2) * vyska) / 3; 
        double objem = Math.PI * polomer * (polomer + Math.Sqrt(Math.Pow(vyska, 2) + Math.Pow(polomer, 2)));

        //výpis
        Console.WriteLine($"Povrch kužele je: {povrch} \nObjem kužele je: {objem}");
    }
}