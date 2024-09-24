using System;

class ComplexNumber
{
    public double Real;
    public double Imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;  
        Imaginary = imaginary;
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        double real = Real + other.Real;
        double imaginary = Imaginary + other.Imaginary;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Subtract(ComplexNumber other)
    {
        double real = Real - other.Real;
        double imaginary = Imaginary - other.Imaginary;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Multiply(ComplexNumber other)
    {
        double real = Real * other.Real - Imaginary * other.Imaginary;
        double imaginary = Imaginary * other.Real + Real * other.Imaginary;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Divide(ComplexNumber other)
    {
        double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;
        double real = (Real * other.Real + Imaginary * other.Imaginary) / denominator;
        double imaginary = (Imaginary * other.Real - Real * other.Imaginary) / denominator;
        return new ComplexNumber(real, imaginary);
    }
    
    public override string ToString()
    {
        return $"{Real} {(Imaginary >= 0 ? "+" : "-")} i{Math.Abs(Imaginary)}";
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zadejte reálnou část prvního komplexního čísla:");
        double real1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Zadejte imaginární část prvního komplexního čísla:");
        double imaginary1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Zadejte reálnou část druhého komplexního čísla:");
        double real2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Zadejte imaginární část druhého komplexního čísla:");
        double imaginary2 = Convert.ToDouble(Console.ReadLine());

        ComplexNumber num1 = new ComplexNumber(real1, imaginary1);
        ComplexNumber num2 = new ComplexNumber(real2, imaginary2);

        ComplexNumber sum = num1.Add(num2);
        ComplexNumber difference = num1.Subtract(num2);
        ComplexNumber product = num1.Multiply(num2);
        ComplexNumber quotient = num1.Divide(num2);

        Console.WriteLine("Součet: " + sum);
        Console.WriteLine("Rozdíl: " + difference);
        Console.WriteLine("Součin: " + product);
        Console.WriteLine("Podíl: " + quotient);
    }
}