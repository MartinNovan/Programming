namespace _07_assignment;

internal static class Program
{
    private static void Main()
    {
        while (true)
        {
            Input();
            Print();
        }
    }

    private static void Input()
    {
        Console.WriteLine("Enter width of the block");
        double width = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter height of the block");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter depth of the block");
        double depth = Convert.ToDouble(Console.ReadLine());

        if (CheckValues(width, height, depth))
        {
            Block block = new Block
            {
                Width = width,
                Height = height,
                Depth = depth
            };
            Blocks.Add(block);
        }
        else
        {
            Console.WriteLine("Invalid values");
        }
    }

    private static void Print()
    {
        int index = 1;
        foreach (var block in Blocks)
        {
            Console.WriteLine($"Block {index++}:");
            Console.WriteLine($"  Width: {block.Width}, Height: {block.Height}, Depth: {block.Depth}, Is Cube: {block.IsCube}, Volume: {block.Volume}, Surface Area: {block.SurfaceArea}");
        }
    }
    private static bool CheckValues(double width, double height, double depth)
    {
        return width > 0 && height > 0 && depth > 0;
    }
    public class Block
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Volume => Width * Height * Depth;
        public double SurfaceArea => 2 * (Width * Height + Height * Depth + Width * Depth);
        public bool IsCube => Width == Height && Height == Depth;
        public void Add(Block block)
        {
            Width += block.Width;
            Height += block.Height;
            Depth += block.Depth;
        }
    }

    private static ICollection<Block> Blocks { get; } = new List<Block>();
}