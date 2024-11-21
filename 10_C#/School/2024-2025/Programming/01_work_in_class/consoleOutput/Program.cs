namespace ConsoleOutput
{
    internal static class Program
    {
        static void Main()
        {
            int firstNumber = 7;
            int secondNumber = 3;
            int sum = CalculateSum(firstNumber, secondNumber);
            DisplaySum(firstNumber, secondNumber, sum);
        }

        private static int CalculateSum(int a, int b)
        {
            return a + b;
        }

        private static void DisplaySum(int a, int b, int sum)
        {
            Console.WriteLine($"{a} + {b} = {sum}");
        }
    }
}