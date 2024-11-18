using System;

class Program
{
    static void Main()
    {
        CalculateCircle(5);
    }

    static void CalculateCircle(double radius)
    {
        double area = 3.14 * radius * radius;
        double circumference = 2 * 3.14 * radius;
        Console.WriteLine("Area: " + area);
        Console.WriteLine("Circumference: " + circumference);
    }
}
