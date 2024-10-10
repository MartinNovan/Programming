using System;

namespace VypisKonzole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vypis bez odradkovani
            int prvniCislo = 7;
            int druheCislo = 3;
            int soucetDvouCisel = prvniCislo + druheCislo;
            Console.Write("7+3=");
            Console.WriteLine(soucetDvouCisel);

            Console.WriteLine("{0} + {1} = {2}", prvniCislo, druheCislo, soucetDvouCisel);
            Console.WriteLine($"{prvniCislo} + {druheCislo} = {soucetDvouCisel}");
        }
    }
}