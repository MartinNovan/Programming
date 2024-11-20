using System.Globalization;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] images = {
            "+---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n========="
        };
        string[] words = {
        "stonožka" , "kabel" , "zápach" , "konektor" , "desky" , "mlha" , "prstýnek" , "humor" , "obloha" , "pasta" , "diadém" , "věšák" , "kořen" , "slípka" , "matka" , "reakce" , "poprava" , "kapesník" , "jízdenka" , "ukazovátko" , "novela" , "služebník" , "předkrm" , "tablet" , "spor" , "kord" , "sklíčko" , "slovník" , "sklárna" , "vlákno" , "lyže" , "izolepa" , "divadlo" , "kolo" , "utrpení" , "vaření" , "kalich" , "koule" , "psát" , "proton" , "doly" , "lepra" , "ilustrace" , "trik" , "nástupiště" , "knihovnice" , "broskvoň" , "houba" , "kašel" , "vyvrhel"
        };

        Random rd = new Random();

        string word = words[rd.Next(words.Length)];

        int wrongCount = 0;
        char[] guessed = new char[26];  //pole pro ukládání vyzkoušených písmen
        int guessedIndex = 0;   //proměnná pro vkládání charakterů do pole guessed

        char[] chars = word.ToCharArray();
        char randomChar = word[rd.Next(chars.Length)];
        ReplaceCharacters(chars, randomChar);

        while (wrongCount < images.Length - 1 && new string(chars) != word)
        {
            Console.WriteLine(images[wrongCount]);
            Console.WriteLine(new string(chars));
            Console.WriteLine("Guessed letters: " + new string(guessed)); //vypsání vyzkoušených písmen
            Console.WriteLine("Zadej písmeno:");
            char c = Console.ReadLine()[0];
            guessed[guessedIndex++] = c; //zapsání charakteru do pole guessed
            bool contains = FillIfContains(word, chars, c);
            if (!contains)
            {
                wrongCount++;
            }
       
                Console.Clear();
        }
        if (wrongCount == images.Length - 1)
        {
            Console.WriteLine(images[wrongCount]);
            Console.WriteLine("Prohrál jsi");
        }
        else
        {
            Console.WriteLine(images[wrongCount]);
            Console.WriteLine(new string(chars));
            Console.WriteLine("Vyhrál jsi");
        }
        Console.ReadLine();

        }

    static void ReplaceCharacters(char[] chars, char characterToKeep)
    {
        for (int i = 0; i < chars.Length; i++)
        {
            if (characterToKeep != chars[i])
            {
                chars[i] = '_';
            }
        }
    }

    static bool FillIfContains(string word, char[] chars, char c)
    {
        bool contains = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == c)
            {
                chars[i] = c;
                contains = true;
            }
        }
        return contains;
    }
}