namespace _06_assignment;

public interface IBook
{
    double GetValue();
}

// Classes for different types of books, each implementing IBook
public class FantasyBook(string bookName, string author, double price) : IBook
{
    public string BookName { get; } = bookName;
    public string Author { get; set; } = author;
    private double Price { get; } = price;

    // Constructor to set book properties

    // Method to get the value of the fantasy book
    public double GetValue()
    {
        return Price;
    }
}

public class ScifiBook(string bookName, string author, double price, int pageCount)
    : IBook
{
    // Similar to FantasyBook, but with an added page count
    public string BookName { get; } = bookName;
    public string Author { get; set; } = author;
    private double Price { get; } = price;
    private int PageCount { get; } = pageCount;

    // The value of the sci-fi book depends on the price and page count
    public double GetValue()
    {
        return Price + 10 * (PageCount / 100.0);
    }
}

public class DetectiveBook(string bookName, string author, double price, int numberOfVictims)
    : IBook
{
    // Similar to ScifiBook, but instead of page count, it has the number of victims
    public string BookName { get; } = bookName;
    public string Author { get; set; } = author;
    private double Price { get; } = price;
    private int NumberOfVictims { get; } = numberOfVictims;

    // The value of the detective book depends on the price and number of victims
    public double GetValue()
    {
        return Price + 20 * NumberOfVictims;
    }
}

public static class Program
{
    // Method to compare two books and select the better one
    private static IBook BetterBook(IBook book0, IBook book1)
    {
        if (book0.GetValue() > book1.GetValue())
        {
            return book0;
        }
        else if (book0.GetValue() < book1.GetValue())
        {
            return book1;
        }
        else
        {
            // If they have the same value, choose randomly
            Random random = new Random();
            int winnerBook = random.Next(0, 2);
            return winnerBook == 0 ? book0 : book1;
        }
    }

    public static void Main()
    {
        // Creating a list of books of different genres
        List<IBook> books =
        [
            new FantasyBook("The Hobbit", "J.R.R. Tolkien", 15.99),
            new ScifiBook("Dune", "Frank Herbert", 20.00, 412),
            new DetectiveBook("The Girl with the Dragon Tattoo", "Stieg Larsson", 25.00, 5)
        ];

        // Finding the best book by comparing all books in the list
        IBook bestBook = books[0];
        foreach (var book in books.Skip(1))
        {
            bestBook = BetterBook(bestBook, book);
        }

        // Getting the name of the best book based on its type
        string bookName = "";
        if (bestBook is FantasyBook fantasyBook)
            bookName = fantasyBook.BookName;
        else if (bestBook is ScifiBook scifiBook)
            bookName = scifiBook.BookName;
        else if (bestBook is DetectiveBook detectiveBook)
            bookName = detectiveBook.BookName;

        // Outputting the best book and its value
        Console.WriteLine($"The best book is: {bookName} - {bestBook.GetValue():F2}");
    }
}