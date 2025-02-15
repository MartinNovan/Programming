namespace _01_assigment
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the first number");
            double firstNumber = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Enter the operator (+, -, *, /, ^):");
            char operatorChar = char.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Enter the second number");
            double secondNumber = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double result;
            switch (operatorChar)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return;
                    }
                    break;
                case '^':
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    return;
            }
            Console.WriteLine(result);
        }
    }
}