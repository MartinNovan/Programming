using System;

class Program
{
    static void Main()
    {
        // This function multiplies two numbers into the "product" variable to then print it in console 
        int product = Multiply(4, 5);
        Console.WriteLine("Product is: " + product);
    }

    // This function multiplies two numbers that are inputed
    static int Multiply(int a, int b)
    {
        // Multiply the inputed numbers so we can return them for next usage
        return a * b;
    }
}
