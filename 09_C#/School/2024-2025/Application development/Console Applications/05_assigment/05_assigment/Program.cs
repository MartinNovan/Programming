using System.Text;
namespace _05_assigment
{
    internal static class Program
    {
        private static void Main()
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
            foreach (var t in canvas)
            {
                stringBuilder.AppendLine(new string(t));
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
        }

        static void Clear(char[][] canvas)
        {
            foreach (var t in canvas)
            {
                for (int j = 0; j < t.Length; j++)
                {
                    t[j] = ' ';
                }
            }
        }
    }

    internal abstract class Shape(int x, int y, int speedX, int speedY, char[][] canvas)
    {
        protected int X { get; private set; } = x;
        protected int Y { get; private set; } = y;
        protected int SpeedX { get; set; } = speedX;
        protected int SpeedY { get; set; } = speedY;
        protected char[][] Canvas { get; } = canvas;

        public virtual void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }

    internal sealed class Rectangle(int x, int y, int speedX, int speedY, char[][] canvas, int width, int height)
        : Shape(x, y, speedX, speedY, canvas)
    {
        private int Bottom()
        {
            return Y + Height;
        }

        public void Draw()
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

        private int Left()
        {
            return X;
        }

        private int Right()
        {
            return X + Width;
        }

        private int Top()
        {
            return Y;
        }

        private int Width { get; } = width;
        private int Height { get; } = height;

        public override void Move()
        {
            base.Move();
            if (Left() <= 0 || Right() >= Canvas[0].Length - 1) SpeedX *= -1;
            if (Top() <= 0 || Bottom() >= Canvas.Length - 1) SpeedY *= -1;
        }
    }
}