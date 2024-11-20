var words = new List<string>();
int currentIndex = -1;
while (true)
{
    string? input = Console.ReadLine();
    if (input != null)
    {
        string[] parts = input.Split(':');
        string command = parts[0].Trim();
        string? argument = parts.Length > 1 ? parts[1].Trim() : null;

        switch (command.ToLower())
        {
            case "add":
                if (!string.IsNullOrEmpty(argument))
                {
                    words.Add(argument);
                    currentIndex = words.Count - 1;
                    Console.WriteLine(argument);
                }
                else
                {
                    Console.WriteLine("Invalid command format.");
                }
                break;

            case "back":
                if (currentIndex > 0)
                {
                    currentIndex--;
                    Console.WriteLine(words[currentIndex]);
                }
                else
                {
                    Console.WriteLine(words[0]);
                }
                break;

            case "forward":
                if (currentIndex < words.Count - 1)
                {
                    currentIndex++;
                    Console.WriteLine(words[currentIndex]);
                }
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}