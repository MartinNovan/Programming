using System.Text;
using System.Threading;
namespace úkol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] canvas = new char[20][];
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i] = new char[20];
            }
            Rectangle rectangle = new Rectangle(5, 5, 1, 1, canvas, 5, 7);
            while (true)
            {
                Thread.Sleep(50);
                Clear(canvas);
                rectangle.Move();
                rectangle.Draw();
                Draw(canvas);
            }

        }

        static void Draw(char[][] canvas)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < canvas.Length; i++)
            {
                stringBuilder.AppendLine(new string(canvas[i]));
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
        }

        static void Clear(char[][] canvas)
        {
            for (int i = 0; i < canvas.Length; i++)
            {
                for (int j = 0; j < canvas[i].Length; j++)
                {
                    canvas[i][j] = ' ';
                }
            }
        }
    }

    internal abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public char[][] Canvas { get; set; }

        public Shape(int x, int y, int speedX, int speedY, char[][] canvas)
        {
            X = x;
            Y = y;
            SpeedX = speedX;
            SpeedY = speedY;
            Canvas = canvas;
        }

        public abstract void Draw();
        public abstract int Top();
        public abstract int Bottom();
        public abstract int Left();
        public abstract int Right();

        public virtual void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }

    internal class Rectangle : Shape
    {
        public override int Bottom()
        {
            return Y + Height;
        }

        public override void Draw()
        {
            for (int x = Left(); x <= Left() + Width; x++)
            {
                if (x < 0) continue;
                if (x >= Canvas[0].Length) break;
                int y = Top();
                if (y >= 0 && y < Canvas.Length)
                {
                    Canvas[y][x] = '■';
                }
                y = Bottom();
                if (y >= 0 && y < Canvas.Length)
                {
                    Canvas[y][x] = '■';
                }
            }
            for (int y = Top(); y <= Top() + Height; y++)
            {
                if (y < 0) continue;
                if (y >= Canvas.Length) break;
                int x = Left();
                if (x >= 0 && x < Canvas[0].Length)
                {
                    Canvas[y][x] = '■';
                }
                x = Right();
                if (x >= 0 && x < Canvas[0].Length)
                {
                    Canvas[y][x] = '■';
                }
            }
        }

        public override int Left()
        {
            return X;
        }

        public override int Right()
        {
            return X + Width;
        }

        public override int Top()
        {
            return Y;
        }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int speedX, int speedY, char[][] canvas, int width, int height)
            : base(x, y, speedX, speedY, canvas)
        {
            Width = width;
            Height = height;
        }

        public override void Move()
        {
            base.Move();
            if (Left() <= 0 || Right() >= Canvas[0].Length - 1) SpeedX *= -1;
            if (Top() <= 0 || Bottom() >= Canvas.Length - 1) SpeedY *= -1;
        }
    }
}