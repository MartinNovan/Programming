namespace Counting
{
    internal static class Program
    {
        static void Main()
        {
            int x = 10;
            int y = 4;
            float z = 4.5f;

            DisplayArithmeticOperations(x, y, z);
        }

        private static void DisplayArithmeticOperations(int x, int y, float z)
        {
            Console.WriteLine($"Sum: {x + y}");
            Console.WriteLine($"Subtraction: {x - y}");
            Console.WriteLine($"Multiplication: {x * y}");
            Console.WriteLine($"Integer Division: {x / y}");
            Console.WriteLine($"Decimal Division: {x / z}");

            int result = CalculateExpression();
            Console.WriteLine($"Result of expression: {result}");
        }

        private static int CalculateExpression()
        {
            return 2 * 3 + 5 * 4;
        }
    }
}