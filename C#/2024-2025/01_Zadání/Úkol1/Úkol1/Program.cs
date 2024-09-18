using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Zadejte číslo pro ciferný součet:");
        char[] arr = Console.ReadLine().ToCharArray();              // zapsání rovnou do pole charakterů namísto převádění stringu
        int sum = 0;                                                // vytvoření proměnné pro ciferný součet 
        bool isItGood = true;                                       // boolean pro kontrolu pole (defaultně je true, pokud neprojde kontrolou bude false)
        for (int i = 0; i < arr.Length; i++)                        // cyklus pro zkontrolování pole zda se zde nachází jiné charaktery než čísla
        {
            if (!char.IsDigit(arr[i]))                              // pokud na pozici v array nebude číslo provede se příkaz který je hned pod tímto řádkem
            {
                Console.WriteLine($"Neplatný znak nalezen: '{arr[i]}' na pozici {i+1}");
                isItGood = false;                                   // pokud se našel špatný znak tak se isItGood přepne do false a ciferný součet se neprovede
            }
        }
        if (!isItGood)                                              // pokud isItGood je false tak se program zeptá zda chce uživatel zopakovat zadání
        {
            Console.WriteLine("Chcete zopakovat zadání čísla? (Y/N)");
            string answer = "N";                                    // pokud uživatel odentruje bez zadání bude se defaultně brát N jako odpověď podobně jako v Linux terminálu 
            answer = Console.ReadLine();
            if (answer.ToUpper() != "Y") {                          // pokud je answer cokoliv jiného než "Y" tak se program ukončí v opačném případě se program restartuje
                Console.WriteLine("Pro zavření zmáčkněte enter.");
            }
            else
            {
                Main(args);                                         //spustí znova main, jinak řečeno restartuji celý program
            }
        }
        else
        {
            for (int j = 0; j < arr.Length; j++)                    // cyklus pro sečtení cifer v array kterou jsme si vytvořili
            {
                int.TryParse(arr[j].ToString(), out int number);    // převedení datového typu na integer
                sum += number;                                      // sečtení cifer dohromady
            }
            Console.WriteLine($"Ciferný součet je: {sum}");         // vypsání výsledku

            //Kopie kódu ze špatně zadaného vstupu, je zde aby si uživatel mohl znovu spustit program 
            Console.WriteLine("\nChcete zopakovat zadání čísla? (Y/N)");
            string answer = "N";                                    // pokud uživatel odentruje bez zadání bude se defaultně brát N jako odpověď podobně jako v Linux terminálu 
            answer = Console.ReadLine();
            if (answer.ToUpper() != "Y")
            {                          // pokud je answer cokoliv jiného než "Y" tak se program ukončí v opačném případě se program restartuje
                Console.WriteLine("Pro zavření zmáčkněte enter.");
            }
            else
            {
                Main(args);                                         //spustí znova main, jinak řečeno restartuji celý program
            }

        }
        Console.Read();
    }
}
