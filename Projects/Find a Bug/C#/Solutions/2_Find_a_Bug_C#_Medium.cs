List<int> numberList = new List<int>(){1,2,3}; 
for (int i = numberList.Count - 1; i >= 0; i--) // Projetí celého pole
{
    if (numberList[i] == 2) // V podmínce je původně jen jedno = což slouží k přiřazení hodnoty ale ne k porovnaní, pro porovnání používáme == nebo === (== a === fungují podobně ale nejsou stejná!, zde bude fungovat obojí)
    {
        numberList.RemoveAt(i); // Odstranění prvku na indexu i
    }
}
Console.WriteLine(string.Join(", ", numberList)); // Požadovaný výstup: 1, 3