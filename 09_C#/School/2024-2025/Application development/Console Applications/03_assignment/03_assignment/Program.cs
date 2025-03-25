namespace _03_assignment;

internal static class Program
{
    private static void Main()
    {
        string[] images =
        [
            "+---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========",
            "+---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n========="
        ];
        string[] words =
        [
            "centipede", "cable", "odor", "connector", "boards", "fog", "ring", "humor", "sky", "paste", 
            "diadem", "hanger", "root", "hen", "mother", "reaction", "execution", "handkerchief", "ticket", 
            "pointer", "novel", "servant", "appetizer", "tablet", "dispute", "sword", "slide", "dictionary", 
            "classwork", "thread", "skis", "tape", "theater", "bicycle", "suffering", "cooking", "chalice", 
            "ball", "write", "proton", "mines", "leprosy", "illustration", "trick", "platform", "librarian", 
            "peach tree", "mushroom", "cough", "outcast"
        ];

        Random rd = new Random();

        string word = words[rd.Next(words.Length)];

        int wrongCount = 0;
        char[] guessed = new char[26];  // Array to store guessed letters
        int guessedIndex = 0;   // Variable for inserting characters into the guessed array

        char[] chars = word.ToCharArray();
        char randomChar = word[rd.Next(chars.Length)];
        ReplaceCharacters(chars, randomChar);

        while (wrongCount < images.Length - 1 && new string(chars) != word)
        {
            Console.WriteLine(images[wrongCount]);
            Console.WriteLine(new string(chars));
            Console.WriteLine("Guessed letters: " + new string(guessed)); // Display guessed letters
            Console.WriteLine("Enter a letter:");
            char c = Console.ReadLine()[0];
            guessed[guessedIndex++] = c; // Store the character in the guessed array
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
            Console.WriteLine("You lost");
        }
        else
        {
            Console.WriteLine(images[wrongCount]);
            Console.WriteLine(new string(chars));
            Console.WriteLine("You won");
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