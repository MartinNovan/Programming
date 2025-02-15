namespace SpecialSymbols
{
    internal static class Program
    {
        static void Main()
        {
            DisplaySpecialSymbols();
        }

        private static void DisplaySpecialSymbols()
        {
            Console.WriteLine("\"hello\""); // Output with quotes
            Console.WriteLine("C:\\programming\\hello"); // Output path
            Console.WriteLine("Martin \n\tNovan"); // New line and tab
        }
    }
}