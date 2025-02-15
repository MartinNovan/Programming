namespace _05_assigment
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Select the value you want to calculate:\n1) Distance (S)\n2) Acceleration (a)\n3) Time (t)");
            double calculationChoice = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            switch (calculationChoice)
            {
                case 1:
                    var distance = CalculateDistance();
                    Console.WriteLine($"Distance (S) = {distance}");
                    break;
                case 2:
                    var acceleration = CalculateAcceleration();
                    Console.WriteLine($"Acceleration (a) = {acceleration}");
                    break;
                case 3:
                    var time = CalculateTime();
                    Console.WriteLine($"Time (t) = {time}");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Restart();
        }

        private static double CalculateDistance()
        {
            Console.WriteLine("Enter the value of acceleration (a):");
            double a = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter the value of time (t):");
            double t = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            return (a * Math.Pow(t, 2)) / 2;
        }
    
        private static double CalculateAcceleration()
        {
            Console.WriteLine("Enter the value of distance (S):");
            double s = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter the value of time (t):");
            double t = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            if (t <= 0)
            {
                Console.WriteLine("'t' cannot be zero or negative.");
                return CalculateAcceleration();
            }

            return (2 * s) / Math.Pow(t, 2);
        }

        private static double CalculateTime()
        {
            Console.WriteLine("Enter the value of distance (S):");
            double s = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            if (s < 0)
            {
                Console.WriteLine("'S' cannot be negative.");
                return CalculateTime();
            }

            Console.WriteLine("Enter the value of acceleration (a):");
            double a = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            if (a <= 0)
            {
                Console.WriteLine("'a' cannot be zero or negative.");
                return CalculateTime();
            }

            return Math.Sqrt((2 * s) / a);
        }

        private static void Restart()
        {
            Console.WriteLine("Do you want to repeat? Y/N (default: N)");
            string? answer = Console.ReadLine();
            if (answer?.ToUpper() == "Y")
            {
                Console.Clear();
                Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
