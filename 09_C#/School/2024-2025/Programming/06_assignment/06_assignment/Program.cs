namespace _06_assignment;

internal static class Program
{
    private static void Main()
    {
        double initialValue = GetInitialValue();
        double step = GetStep();
        int repetitions = GetRepetitions();

        if (Math.Abs(step) >= 1)
        {
            Console.WriteLine("Step must be less than 1!");
            return;
        }

        double[] sequence = GenerateGeometricSequence(initialValue, step, repetitions);
        DisplaySequence(sequence);
        double sum = CalculateSum(sequence);
        Console.WriteLine($"\nThe sum of the elements in the geometric series is: {sum}");

        if (repetitions >= 5)
        {
            double sumFirstAndFifth = sequence[0] + sequence[4];
            Console.WriteLine($"The sum of the first and fifth elements is: {sumFirstAndFifth}");
        }
    }

    private static double GetInitialValue()
    {
        Console.WriteLine("Enter the initial value:");
        return double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    private static double GetStep()
    {
        Console.WriteLine("Enter the step:");
        return double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    private static int GetRepetitions()
    {
        Console.WriteLine("Enter the number of repetitions:");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    private static double[] GenerateGeometricSequence(double initialValue, double step, int repetitions)
    {
        double[] sequence = new double[repetitions];
        sequence[0] = initialValue;

        for (int i = 1; i < repetitions; i++)
        {
            sequence[i] = sequence[i - 1] * step;
        }

        return sequence;
    }

    private static void DisplaySequence(double[] sequence)
    {
        Console.WriteLine("\nElements of the geometric sequence:");
        for (int i = 0; i < sequence.Length; i++)
        {
            Console.WriteLine($"a{i + 1} = {sequence[i]}");
        }
    }

    private static double CalculateSum(double[] sequence)
    {
        double sum = 0;
        foreach (double value in sequence)
        {
            sum += value;
        }
        return sum;
    }
}
