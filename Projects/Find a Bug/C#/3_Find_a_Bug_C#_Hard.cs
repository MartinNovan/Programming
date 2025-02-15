// Here are 2 ways to achieve the goal
// 1st way (Inserting some value into the string text, instead of null):
Console.WriteLine("1st Way:");
string text = "Something"; // Assigning some value 
if (text.Length > 0)
{
    Console.WriteLine("Text is not empty");
}
else
{
    Console.WriteLine("Text is empty");
}

// 2nd way (modifying the condition when the string is null) *more suitable*:
Console.WriteLine("2nd Way:");
string text2 = null;
if (!string.IsNullOrEmpty(text2)) // The check is the same as before, but the function additionally checks if the value is not null
{
    Console.WriteLine("Text is not empty");
}
else
{
    Console.WriteLine("Text is empty");
}
// The result is to print something to the console
// Simple option: Text is not empty
// More complex option: Text is empty