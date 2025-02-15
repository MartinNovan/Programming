namespace _01_work_in_class;

internal class Program
{
    private static void Main()
    {
        string text = "hi";             //Create a string
        Console.WriteLine(text[0]);     //Print the first character of the string
        char c = text[0];               //Store the first character of the string in variable 

        int a = 1;                      //Create an integer
        double d = 1.1;                 //Create a double
        float f = 1.1f;                 //Create a float

        string input = Console.ReadLine(); //Read input from the console (in this project input is x,x,x and we are inputing numbers as 'x'!)
        if (input.ToLower() == "calculate")//convert characters to lowercase
        {

        }
        if (input.ToUpper() == "CALCULATE")//convert characters to uppercase
        {

        }

        string[] values = input.Split(',');//inserting a split string into an array by separating it with a comma, MUST USE SINGLE COMMASTS
        int sum = 0;                      //creating a variable for the result after addition 
        for (int i = 0; i < values.Length; i++) { //loop to add the numbers in the array we created
            int.TryParse(values[i], out int value); //convert data type to integer
            sum += value;            //adding numbers together
        }
        Console.WriteLine(sum); //output the answer

        Console.Read();
    }
}