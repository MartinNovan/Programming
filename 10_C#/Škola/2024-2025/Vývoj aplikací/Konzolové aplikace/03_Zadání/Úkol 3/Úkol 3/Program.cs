using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Board board = new Board();
        char playerToken = 'O';
        while (!board.Win())
        {
            if (playerToken == 'O') playerToken = 'X';
            else playerToken = 'O';

            Console.Clear();
            board.Print();
            Console.WriteLine("Hráč " + playerToken + " je na tahu.");

            int x, y;
            do
            {
                Console.WriteLine("Zadejte souřadnici x (sloupce)");
            } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x > 2);

            do
            {
                Console.WriteLine("Zadejte souřadnici y (řádky)");
            } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y > 2);

            if (board.IsCellFree(x, y))
            {
                board.Play(x, y, playerToken);
            }
        }

        Console.Clear();
        board.Print();
        Console.WriteLine("Vyhrál hráč " + playerToken);
        Console.ReadLine();
    }
}

public class Board
{
    public char[][] Layout;

    public Board()
    {
        Layout = new char[3][];
        for (int i = 0; i < 3; i++)
        {
            Layout[i] = new char[3];
        }
    }

    public void Print()
    {
        Console.WriteLine("   0 1 2\n   # # #");
        for (int i = 0; i < Layout.Length; i++)
        {
            string row = new string(Layout[i]).Replace('\0', ' ');
            Console.WriteLine(i + " #" + row[0] + " " + row[1] + " " + row[2] + "#");
        }
        Console.WriteLine("   # # #");
    }

    public bool IsCellFree(int x, int y)
    {
        return Layout[y][x] == default(char);
    }

    public bool CheckRows()
    {
        if (Layout[0][0] == Layout[1][0] && Layout[1][0] == Layout[2][0] && Layout[2][0] != default(char)) return true;
        if (Layout[0][1] == Layout[1][1] && Layout[1][1] == Layout[2][1] && Layout[2][1] != default(char)) return true;
        return Layout[0][2] == Layout[1][2] && Layout[1][2] == Layout[2][2] && Layout[2][2] != default(char);
    }

    public bool CheckCols()
    {
        if (Layout[0][0] == Layout[0][1] && Layout[0][1] == Layout[0][2] && Layout[0][2] != default(char)) return true;
        if (Layout[1][0] == Layout[1][1] && Layout[1][1] == Layout[1][2] && Layout[1][2] != default(char)) return true;
        return Layout[2][0] == Layout[2][1] && Layout[2][1] == Layout[2][2] && Layout[2][2] != default(char);
    }

    public bool CheckDiags()
    {
        if (Layout[0][0] == Layout[1][1] && Layout[1][1] == Layout[2][2] && Layout[2][2] != default(char)) return true;
        return Layout[0][2] == Layout[1][1] && Layout[1][1] == Layout[2][0] && Layout[2][0] != default(char);
    }

    public void Play(int x, int y, char token)
    {
        Layout[y][x] = token;
    }

    public bool Win()
    {
        return CheckRows() || CheckCols() || CheckDiags();
    }
    
}
