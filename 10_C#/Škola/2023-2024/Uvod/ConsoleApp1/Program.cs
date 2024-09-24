using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ukladaní celých kladných čísel");
            byte b = 255;
            ushort us = 65535;
            uint ui = uint.MaxValue;
            ulong ul = ulong.MaxValue;
            Console.WriteLine(b + "     1byte");
            Console.WriteLine(us + "    16bitu");
            Console.WriteLine(ui + "    32bitu");
            Console.WriteLine(ul + "    64bitu");

            Console.WriteLine("Ukládání celých čísel kladné/záporné");
            short s = short.MaxValue;
            int i = int.MaxValue;
            long l = long.MaxValue;
            Console.WriteLine(s);
            Console.WriteLine(i);
            Console.WriteLine(l);

            Console.WriteLine("ukládání reálných čísel");
            float f = 0.1f;
            double d = 0.1;
            decimal dec = 0.1m;
            Console.WriteLine(f + "16bit");
            Console.WriteLine(d + "32bit");
            Console.WriteLine(dec + "128bit");
            
            Console.WriteLine("True/false dat. typ");
            bool bl = true;
            if(bl) {
                Console.WriteLine(bl);
            } else
            {
                Console.WriteLine(bl);
            }
            
            Console.WriteLine("Textové dat. typy");
            char p = 'p';
            string str = "ahoj";
            Console.WriteLine("char je pouze 1 charakter, string je obyč. string");
            Console.WriteLine(p);
            Console.WriteLine(str);
            str = str.Replace('a','b');
            Console.WriteLine(str);
            Console.Read();

            Program prg = new Program();

            int[] pole = new int[10];
            pole[1] = 99;
            Console.WriteLine(pole[1]);
            Console.Read();


            Console.WriteLine("Zadej svoje jméno :)");
            string jmeno = Console.ReadLine();
            Console.WriteLine("Tvoje jméno je: " + jmeno);
            Console.Read();
        }
    }
}
