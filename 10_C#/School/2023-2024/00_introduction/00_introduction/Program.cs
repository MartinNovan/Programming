namespace _00_introduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Storing positive integers");
            byte b = 255;
            ushort us = 65535;
            uint ui = uint.MaxValue;
            ulong ul = ulong.MaxValue;
            Console.WriteLine(b + "     1 byte");
            Console.WriteLine(us + "    16 bits");
            Console.WriteLine(ui + "    32 bits");
            Console.WriteLine(ul + "    64 bits");

            Console.WriteLine("Storing signed integers");
            short s = short.MaxValue;
            int i = int.MaxValue;
            long l = long.MaxValue;
            Console.WriteLine(s);
            Console.WriteLine(i);
            Console.WriteLine(l);

            Console.WriteLine("Storing floating-point numbers");
            float f = 0.1f;
            double d = 0.1;
            decimal dec = 0.1m;
            Console.WriteLine(f + " 16 bits");
            Console.WriteLine(d + " 32 bits");
            Console.WriteLine(dec + " 128 bits");
            
            Console.WriteLine("Boolean data type");
            bool bl = true;
            if(bl) {
                Console.WriteLine(bl);
            } else
            {
                Console.WriteLine(bl);
            }
            
            Console.WriteLine("Text data types");
            char p = 'p';
            string str = "hello";
            Console.WriteLine("char is only 1 character, string is a regular string");
            Console.WriteLine(p);
            Console.WriteLine(str);
            str = str.Replace('a','b');
            Console.WriteLine(str);
            Console.Read();

            Program prg = new Program();

            int[] array = new int[10];
            array[1] = 99;
            Console.WriteLine(array[1]);
            Console.Read();

            Console.WriteLine("Enter your name :)");
            string? name = Console.ReadLine();
            Console.WriteLine("Your name is: " + name);
            Console.Read();
        }
    }
}