namespace _02_assigment;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Enter a number for the digit sum:");
        char[] arr = Console.ReadLine().ToCharArray(); // Directly store input into a character array
        int sum = 0; // Variable for the digit sum
        bool isValidInput = true; // Boolean to check the validity of the input (default is true)

        // Loop to check if the array contains only digits
        for (int i = 0; i < arr.Length; i++)
        {
            if (!char.IsDigit(arr[i])) // If the character is not a digit
            {
                Console.WriteLine($"Invalid character found: '{arr[i]}' at position {i + 1}");
                isValidInput = false; // Set isValidInput to false if an invalid character is found
            }
        }

        if (!isValidInput) // If the input is not valid
        {
            Console.WriteLine("Do you want to re-enter the number? (Y/N)");
            string? answer;
            answer = Console.ReadLine();
            if (answer == "") {answer = "Y";} // Default answer is Y if the user just presses enter
            if (answer != null && answer.ToUpper() != "Y") // If the answer is anything other than "Y", exit the program
            {
                Console.WriteLine("Press enter to close.");
            }
            else
            {
                Main(); // Restart the program
            }
        }
        else
        {
            // Loop to sum the digits in the array
            foreach (var t in arr)
            {
                int.TryParse(t.ToString(), out int number); // Convert character to integer
                sum += number; // Add the digit to the sum
            }
            Console.WriteLine($"The digit sum is: {sum}"); // Output the result

            // Prompt to re-enter the number
            Console.WriteLine("\nDo you want to re-enter the number? (Y/N)");
            string? answer;
            answer = Console.ReadLine();
            if (answer == "") {answer = "Y";} // Default answer is Y if the user just presses enter
            if (answer != null && answer.ToUpper() != "Y") // If the answer is anything other than "Y", exit the program
            {
                Console.WriteLine("Press enter to close.");
            }
            else
            {
                Main(); // Restart the program
            }
        }
        Console.Read(); // Wait for user input before closing
    }
}