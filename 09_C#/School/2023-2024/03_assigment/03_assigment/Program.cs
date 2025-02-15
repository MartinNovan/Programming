namespace _03_assigment;

class ComplexNumber(double real, double imaginary)
{
    private readonly double _real = real;
    private readonly double _imaginary = imaginary;

    public ComplexNumber Add(ComplexNumber other)
    {
        double real = _real + other._real;
        double imaginary = _imaginary + other._imaginary;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Subtract(ComplexNumber other)
    {
        double real = _real - other._real;
        double imaginary = _imaginary - other._imaginary;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Multiply(ComplexNumber other)
    {
        double real = _real * other._real - _imaginary * other._imaginary;
        double imaginary = _imaginary * other._real + _real * other._imaginary;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Divide(ComplexNumber other)
    {
        double denominator = other._real * other._real + other._imaginary * other._imaginary;
        double real = (_real * other._real + _imaginary * other._imaginary) / denominator;
        double imaginary = (_imaginary * other._real - _real * other._imaginary) / denominator;
        return new ComplexNumber(real, imaginary);
    }
    
    public override string ToString()
    {
        return $"{_real} {(_imaginary >= 0 ? "+" : "-")} i{Math.Abs(_imaginary)}";
    }
}

static class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the real part of the first complex number:");
        double real1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the imaginary part of the first complex number:");
        double imaginary1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the real part of the second complex number:");
        double real2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the imaginary part of the second complex number:");
        double imaginary2 = Convert.ToDouble(Console.ReadLine());

        ComplexNumber num1 = new ComplexNumber(real1, imaginary1);
        ComplexNumber num2 = new ComplexNumber(real2, imaginary2);

        ComplexNumber sum = num1.Add(num2);
        ComplexNumber difference = num1.Subtract(num2);
        ComplexNumber product = num1.Multiply(num2);
        ComplexNumber quotient = num1.Divide(num2);

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Difference: " + difference);
        Console.WriteLine("Product: " + product);
        Console.WriteLine("Quotient: " + quotient);
    }
}