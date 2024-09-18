using System;
using System.ComponentModel.Design;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("zadej úlohu kterou chceš spustit: \n 0) zadání jména \n 1) součet dvou zadaných čísel \n 2) výpočet mzdy");
        int uloha = int.Parse(Console.ReadLine());
        switch (uloha)
        {
            case 0:
                Console.WriteLine("Zadej své jméno:");
                string jmeno = Console.ReadLine();
                if (jmeno == "")
                {
                    Console.WriteLine("Nezadal jsi jméno!");
                }
                else
                {
                    Console.WriteLine($"Vítej {jmeno}!");
                }
                break;
            case 1:
                Console.WriteLine("zadej první číslo:");
                int prvnihodnota = int.Parse(Console.ReadLine());
                Console.WriteLine("Zadej druhé číslo:");
                int druhahodnota = int.Parse(Console.ReadLine());
                Console.WriteLine($"součet je: {prvnihodnota + druhahodnota}");
                break;

            case 2:
                Console.WriteLine("Zadejte jméno:");
                string jmenozamestnance = Console.ReadLine();
                Console.WriteLine("Zadejte mzdu: (ve tvaru např. 25000)");
                int mzda = int.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte dobu odpracovaných měsíců");
                int odpracovano = int.Parse(Console.ReadLine());
                Console.WriteLine($"Jméno: {jmenozamestnance} \nmzda: {mzda}Kč \nOdpracovaných měsíců: {odpracovano} měsíců \nDohromady vyděláno: {mzda * odpracovano}Kč");
                break;
            default:
                Console.WriteLine("Špatná hodnota!");
                break;
        }
        
    }
}