internal class Program
{
    private static void Main(string[] args)
    {
        string text = "ahoj";           //vytvoření stringu
        Console.WriteLine(text[0]);     //vypsání prvního písmene ve stringu
        char c = text[0];               //uložení prvního písmene ve stringu do promenné c

        int a = 1;                      //vytvoření intieger 
        double d = 1.1;                 //vytvoření double 
        float f = 1.1f;                 //vytvoření float

        string input = Console.ReadLine(); //zapisování do proměnné input pomocí konzole v tomto projektu je vstup x,x,x, a zadáváme čísla!
        if (input.ToLower() == "vypocitej")//převedení znaků na malé
        {

        }
        if (input.ToUpper() == "VYPOCITEJ")//převedení znaků na velké
        {

        }

        string[] values = input.Split(',');//vložení rozděleného stringu do pole pomocí oddělení čárkou, MUSÍ SE POUŽÍT JEDNODUCHÉ UVOZOVKY
        int sum = 0;                      //vytvoření proměnné pro výsledek po sečtení 
        for (int i = 0; i < values.Length; i++) { //cyklus pro sečtení čísel v array kterou jsme si vytvořili
            int.TryParse(values[i], out int value); //převedení datového typu na integer
            sum += value;            //sečtení čísel dohromady
        }
        Console.WriteLine(sum); //vypsání výsledku

        Console.Read();
    }
}