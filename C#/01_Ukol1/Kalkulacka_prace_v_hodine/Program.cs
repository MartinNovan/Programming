using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulacka_prace_v_hodine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte první číslo");
            double prvniCislo = double.Parse(Console.ReadLine());

            Console.WriteLine("Zadejte operátor (+, -, *, /, ^):");
            char znak = char.Parse(Console.ReadLine());

            Console.WriteLine("Zadejte druhé číslo");
            double druheCislo = double.Parse(Console.ReadLine());

            double vysledek = 0;
            switch (znak)
            {
                case '+':
                    vysledek = prvniCislo + druheCislo;
                    break;
                case '-':
                    vysledek = prvniCislo - druheCislo;
                    break;
                case '*':
                    vysledek = prvniCislo * druheCislo;
                    break;
                case '/':
                    if (druheCislo != 0)
                    {
                        vysledek = prvniCislo / druheCislo;
                    }
                    else
                    {
                        Console.WriteLine("Nelze dělit nulou.");
                        return;
                    }
                    break;
                case '^':
                    vysledek = Math.Pow(prvniCislo, druheCislo);
                    break;
                default:
                    Console.WriteLine("Neplatný operátor.");
                    return;
            }
            Console.WriteLine(vysledek);
        }
    }
}