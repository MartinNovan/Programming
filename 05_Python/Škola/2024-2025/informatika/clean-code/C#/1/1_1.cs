using System;

class Program
{
    static void Main()
    {
        double sideA = 3;
        double sideB = 4;
        double hypotenuse = CalculateHypotenuse(sideA, sideB);
        Console.WriteLine("Computed value: " + hypotenuse);
    }

    static double CalculateHypotenuse(double sideA, double sideB)
    {
        double hypotenuse = Math.Sqrt(sideA * sideA + sideB * sideB);
        Console.WriteLine("The result is: " + hypotenuse);
        return hypotenuse;
    }
}
