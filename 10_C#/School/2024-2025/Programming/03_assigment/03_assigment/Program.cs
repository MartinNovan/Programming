namespace Assignment03
{
    internal static class Program
    {
        private static void Main()
        {
            // Input values
            int height = GetHeight();
            int radius = GetRadius();

            // Calculate surface area and volume
            double surfaceArea = CalculateSurfaceArea(radius, height);
            double volume = CalculateVolume(radius, height);

            // Output results
            DisplayResults(surfaceArea, volume);
        }

        private static int GetHeight()
        {
            Console.WriteLine("Enter the height of the cone:");
            return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        }

        private static int GetRadius()
        {
            Console.WriteLine("Enter the radius of the base:");
            return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        }

        private static double CalculateSurfaceArea(int radius, int height)
        {
            return (Math.PI * Math.Pow(radius, 2) * height) / 3;
        }

        private static double CalculateVolume(int radius, int height)
        {
            return Math.PI * radius * (radius + Math.Sqrt(Math.Pow(height, 2) + Math.Pow(radius, 2)));
        }

        private static void DisplayResults(double surfaceArea, double volume)
        {
            Console.WriteLine($"Surface area of the cone is: {surfaceArea}");
            Console.WriteLine($"Volume of the cone is: {volume}");
        }
    }
}