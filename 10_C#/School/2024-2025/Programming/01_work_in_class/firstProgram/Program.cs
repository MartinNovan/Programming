namespace FirstProgram;

internal static class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        WaitForUserInput();
    }

    private static void WaitForUserInput()
    {
        Console.ReadLine(); // Wait for Enter key
        Console.ReadKey(); // Wait for any key
    }
}