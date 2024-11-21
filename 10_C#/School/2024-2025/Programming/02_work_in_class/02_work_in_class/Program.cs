namespace _02_work_in_class
{
    internal static class Program
    {
        private static void Main()
        {
            DisplayMenu();
            int task = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            ExecuteTask(task);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Select the task you want to run: \n 0) Enter your name \n 1) Sum of two numbers \n 2) Salary calculation");
        }

        private static void ExecuteTask(int task)
        {
            switch (task)
            {
                case 0:
                    PromptForName();
                    break;
                case 1:
                    CalculateSum();
                    break;
                case 2:
                    CalculateSalary();
                    break;
                default:
                    Console.WriteLine("Invalid value!");
                    break;
            }
        }

        private static void PromptForName()
        {
            Console.WriteLine("Enter your name:");
            string? name = Console.ReadLine();
            Console.WriteLine(string.IsNullOrEmpty(name) ? "You did not enter a name!" : $"Welcome {name}!");
        }

        private static void CalculateSum()
        {
            Console.WriteLine("Enter the first number:");
            int firstValue = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter the second number:");
            int secondValue = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine($"The sum is: {firstValue + secondValue}");
        }

        private static void CalculateSalary()
        {
            Console.WriteLine("Enter the employee's name:");
            string? employeeName = Console.ReadLine();
            Console.WriteLine("Enter the salary (e.g., 25000):");
            int salary = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter the number of months worked:");
            int monthsWorked = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine($"Name: {employeeName} \nSalary: {salary} CZK \nMonths worked: {monthsWorked} months \nTotal earned: {salary * monthsWorked} CZK");
        }
    }
}