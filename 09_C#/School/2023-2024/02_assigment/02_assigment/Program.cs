namespace _02_assigment
{
    static class Program
    {
        static void Main()
        {
            int[] numbers = [];

            while (true)
            {
                Console.WriteLine("Enter a sequence of numbers separated by commas:");
                string? input = Console.ReadLine();

                try
                {
                    if (input != null) numbers = input.Split(',').Select(int.Parse).ToArray();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter the numbers again.");
                }
            }

            int min = numbers.Min();
            int max = numbers.Max();
            int longestAscendingInterval = AscendingInterval(numbers);

            Console.WriteLine($"The smallest number is {min}.");
            Console.WriteLine($"The largest number is {max}.");
            Console.WriteLine($"The length of the longest ascending interval is {longestAscendingInterval}.");
        }

        static int AscendingInterval(int[] numbers)
        {
            int maxLength = 0;
            int currentLength = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    maxLength = Math.Max(maxLength, currentLength);
                    currentLength = 1;
                }
            }

            maxLength = Math.Max(maxLength, currentLength);

            return maxLength;
        }
    }
}