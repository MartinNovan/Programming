using System.ComponentModel.Design;
using System.Diagnostics;

namespace casino
{
    class Program
    {
        static void Main(string[] args)
        {
            bool maPrachy = prachy();
            if (maPrachy)
            {
                Console.WriteLine("Vítejte v kasínu! :D");
                int kredit = limit();
                Casino(kredit, "");
            }
            else
            {
                Console.WriteLine("Nemůžete vstoupit bez peněz! >:(");
            }
        }

        static bool prachy()
        {
            Console.Clear();
            Console.WriteLine("Máte prachy: Y/N (default:N) ");
            string odpoved = Console.ReadLine();
            if (odpoved == "Y")
            {
                return true;
            }
            else if (odpoved == "N" || odpoved == "")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Špatná hodnota, prosím zadejte správnou hodnotu.");
                Console.ReadKey();
                return prachy();
            }
        }

        static int limit()
        {
            Console.WriteLine("Kolik máte k dispozici peněz?");
            int kredit = int.Parse(Console.ReadLine());
            if (kredit <= 0)
            {
                Console.WriteLine("Nemůže být nula.");
                Console.ReadKey();
                return limit();
            }
            return kredit;
        }

        private static void Casino(int kredit, string poslednihra)
        {
            Console.Clear();
            Console.WriteLine($"Máte {kredit} kreditů!");
            Console.WriteLine("Vyberte si hru: \n1) Ruleta \n2) Uhodni random číslo od 1 do 50 \n99) Exit");
            string hra = Console.ReadLine();
            poslednihra = "";
            if (hra == "1")
            {
                poslednihra = "ruleta";
                Ruleta(kredit, poslednihra);
            }
            else if (hra == "2")
            {
                poslednihra = "randomCislo";
                randomCislo(kredit, poslednihra);
            }
            else if (hra == "99")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Špatná hodnota, zadejte prosím správnou.");
                Console.ReadKey();
                Casino(kredit, poslednihra);
            }
        }

        static int Ruleta(int kredit, string poslednihra)
        {
            Console.Clear();
            Console.WriteLine($"Máte {kredit} kreditů!");
            Random rand = new Random();
            int viteznecislo = rand.Next(0, 37);
            string cervenaCerna = "";
            int cisloSazky = 99;
            Console.WriteLine("Kolik chcete vsadit?");
            int bet = int.Parse(Console.ReadLine());
            if (bet <= 0)
            {
                Console.WriteLine("Nemůžete vsadit negativní hodnotu.");
                Console.ReadKey();
                return Ruleta(kredit, poslednihra);
            }
            else if (bet > kredit)
            {
                Console.WriteLine("Nedostatek kreditů! Máte peníze?");
                Console.ReadKey();
                prachy();
            }

            Console.WriteLine("Chcete vsadit na číslo nebo na barvu? 1) číslo 2) barvu");
            string odpoved = Console.ReadLine();
            if (odpoved == "1")
            {
                Console.WriteLine("Zadejte své sázky (číslo od 0 do 36): ");
                cisloSazky = int.Parse(Console.ReadLine());
            }
            else if (odpoved == "2")
            {
                Console.WriteLine("Vsázíte na červenou či černou? \n1) červená \n2) černá");
                cervenaCerna = Console.ReadLine();
                if (cervenaCerna != "1" && cervenaCerna != "2")
                {
                    Console.WriteLine("Špatně napsaná hodnota.");
                    Console.ReadKey();
                    return Ruleta(kredit, poslednihra);
                }
            }

            int[] redNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            int[] blackNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

            Console.WriteLine($"Výherní číslo je: {viteznecislo}");

            if (cisloSazky != 99 && cisloSazky == viteznecislo)
            {
                kredit += bet * 35;
                Console.WriteLine($"Vyhráli jste {bet * 35} kreditů.");
                Console.WriteLine($"Gratulujeme! Vyhráli jste! Máte: {kredit} kreditů!");
                Console.ReadKey();
                konecHry(kredit, poslednihra);
            }
            else if (cervenaCerna == "1" && redNumbers.Contains(viteznecislo))
            {
                kredit += bet;
                Console.WriteLine($"Vyhráli jste {bet*2} kreditů.");
                Console.WriteLine($"Gratulujeme! Vyhráli jste! Máte: {kredit} kreditů!");
                Console.ReadKey();
                konecHry(kredit, poslednihra);
            }
            else if (cervenaCerna == "2" && blackNumbers.Contains(viteznecislo))
            {
                kredit += bet;
                Console.WriteLine($"Vyhráli jste {bet*2} kreditů.");
                Console.WriteLine($"Gratulujeme! Vyhráli jste! Máte: {kredit} kreditů!");
                Console.ReadKey();
                konecHry(kredit, poslednihra);
            }
            else
            {
                Console.WriteLine("Bohužel, prohráli jste.");
                kredit -= bet;
                Console.WriteLine($"Prohráli jste {bet} kreditů.");
                Console.WriteLine($"Máte {kredit} kreditů.");
                if (kredit <= 0)
                {
                    Console.WriteLine("Jste bez kreditů.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ReadKey();
                    konecHry(kredit, poslednihra);
                }
            }
            return kredit;
        }

        static int randomCislo(int kredit, string poslednihra)
        {
            Console.Clear();
            Console.WriteLine($"Máte {kredit} kreditů!");
            Random rand = new Random();
            int viteznecislo = rand.Next(0, 50);
            Console.WriteLine("Zadejte sázku");
            int bet = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte číslo, které si myslíte, že je správné:");
            int hadanecislo = int.Parse(Console.ReadLine());
            Console.WriteLine($"Výherní číslo je: {viteznecislo}");
            if (hadanecislo < 0 || hadanecislo > 50)
            {
                Console.WriteLine("Špatně zadané číslo!");
                Console.ReadKey();
                randomCislo(kredit, poslednihra);
            }
            if (hadanecislo == viteznecislo)
            {
                kredit += bet * 50;
                Console.WriteLine($"Vyhráli jste {bet * 50} kreditů.");
                Console.WriteLine($"Gratulujeme! Vyhráli jste! Máte: {kredit} kreditů!");
                Console.ReadKey();
                konecHry(kredit, poslednihra);
            }
            else
            {
                Console.WriteLine("Bohužel, prohráli jste.");
                kredit -= bet;
                Console.WriteLine($"Prohráli jste {bet} kreditů.");
                Console.WriteLine($"Máte {kredit} kreditů.");
                if (kredit <= 0)
                {
                    Console.WriteLine("Jste bez kreditů.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ReadKey();
                    konecHry(kredit, poslednihra);
                }
            }
            return kredit;
        }

        static void konecHry(int kredit, string poslednihra)
        {
            Console.WriteLine("Chcete hrát znovu? \n1) Ano \n2) Jiná hra \n3) Ne");
            string odpoved = Console.ReadLine();
            if (odpoved == "1" || odpoved == "")
            {
                if (poslednihra == "ruleta")
                {
                    Ruleta(kredit, poslednihra);
                }
                else if (poslednihra == "randomCislo")
                {
                    randomCislo(kredit, poslednihra);
                }
                else
                {
                    Casino(kredit, poslednihra);
                }
            }
            else if (odpoved == "2")
            {
                Casino(kredit, poslednihra);
            }
            else if (odpoved == "3")
            {
                Console.WriteLine("Děkujeme za hru!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Špatně zadaná hodnota.");
                Console.ReadKey();
                konecHry(kredit, poslednihra);
            }
        }
    }
}
