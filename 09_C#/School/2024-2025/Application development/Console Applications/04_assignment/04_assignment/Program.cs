namespace _04_assignment
{
    internal static class Program
    {
        private static void Main()
        {
            Board board = new Board();
            char playerToken = 'O';
            while (!board.Win())
            {
                playerToken = playerToken == 'O' ? 'X' : 'O';

                Console.Clear();
                board.Print();
                Console.WriteLine("Player " + playerToken + " is up.");

                int x, y;
                do
                {
                    Console.WriteLine("Enter x coordinate (column):");
                } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x > 2);

                do
                {
                    Console.WriteLine("Enter y coordinate (row):");
                } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y > 2);

                if (board.IsCellFree(x, y))
                {
                    board.Play(x, y, playerToken);
                }
            }

            Console.Clear();
            board.Print();
            Console.WriteLine("Player " + playerToken + " wins!");
            Console.ReadLine();
        }
    }

    public class Board
    {
        private readonly char[][] _layout;

        public Board()
        {
            _layout = new char[3][];
            for (int i = 0; i < 3; i++)
            {
                _layout[i] = new char[3];
            }
        }

        public void Print()
        {
            Console.WriteLine("   0 1 2\n   # # #");
            for (int i = 0; i < _layout.Length; i++)
            {
                string row = new string(_layout[i]).Replace('\0', ' ');
                Console.WriteLine(i + " #" + row[0] + " " + row[1] + " " + row[2] + "#");
            }
            Console.WriteLine("   # # #");
        }

        public bool IsCellFree(int x, int y)
        {
            return _layout[y][x] == default(char);
        }

        private bool CheckRows()
        {
            if (_layout[0][0] == _layout[1][0] && _layout[1][0] == _layout[2][0] && _layout[2][0] != default(char)) return true;
            if (_layout[0][1] == _layout[1][1] && _layout[1][1] == _layout[2][1] && _layout[2][1] != default(char)) return true;
            return _layout[0][2] == _layout[1][2] && _layout[1][2] == _layout[2][2] && _layout[2][2] != default(char);
        }

        private bool CheckCols()
        {
            if (_layout[0][0] == _layout[0][1] && _layout[0][1] == _layout[0][2] && _layout[0][2] != default(char)) return true;
            if (_layout[1][0] == _layout[1][1] && _layout[1][1] == _layout[1][2] && _layout[1][2] != default(char)) return true;
            return _layout[2][0] == _layout[2][1] && _layout[2][1] == _layout[2][2] && _layout[2][2] != default(char);
        }

        private bool CheckDiags()
        {
            if (_layout[0][0] == _layout[1][1] && _layout[1][1] == _layout[2][2] && _layout[2][2] != default(char)) return true;
            return _layout[0][2] == _layout[1][1] && _layout[1][1] == _layout[2][0] && _layout[2][0] != default(char);
        }

        public void Play(int x, int y, char token)
        {
            _layout[y][x] = token;
        }

        public bool Win()
        {
            return CheckRows() || CheckCols() || CheckDiags();
        }
    }
}