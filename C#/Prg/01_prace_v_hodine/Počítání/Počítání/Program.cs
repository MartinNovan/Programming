using System;

namespace Pocitani // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10; int y = 4; float z = 4.5f;
            int soucet = x + y;
            int rozdil = x - y;
            int soucin = x * y;
            int celoCiselnyPodil = x / y; //podíl celého čísla
            float DesetinyPodil = x / z;
            Console.WriteLine(soucet);
            Console.WriteLine(rozdil);
            Console.WriteLine(soucin);
            Console.WriteLine(celoCiselnyPodil);
            Console.WriteLine(DesetinyPodil);

            int vysledek = 2 * 3 + 5 * 4;
            Console.WriteLine(vysledek);
        }
    }
}