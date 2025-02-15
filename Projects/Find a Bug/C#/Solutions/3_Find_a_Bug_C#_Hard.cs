// Zde jsou 2 možnosti jak dosáhnout cíle
// 1. způsob (Vložení nějaké hodnoty do stringu text, namísto null):
Console.WriteLine("1. Způsob:");
string text = "Něco"; // dosazení nějáké hodnoty 
if (text.Length > 0)
{
    Console.WriteLine("Text není prázdný");
}
else
{
    Console.WriteLine("Text je prázdný");
}

// 2. způsob (upravení podmínky když je string null) *vhodnější*:
Console.WriteLine("2. Způsob:");
string text2 = null;
if (!string.IsNullOrEmpty(text2)) // Kontrola stejná jako předchozí, jenže funkce navíc kontroluje zda hodnota není null
{
    Console.WriteLine("Text není prázdný");
}
else
{
    Console.WriteLine("Text je prázdný");
}