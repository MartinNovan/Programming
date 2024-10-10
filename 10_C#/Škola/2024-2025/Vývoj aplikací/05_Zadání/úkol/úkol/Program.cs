using System.Globalization;

public interface IBook
{
    double GetValue();
}

// Třídy pro různé typy knih, každá implementuje IBook
public class FantasyBook : IBook
{
    public string BookName { get; set; }
    public string Autor { get; set; }
    public double Price { get; set; }

    // Konstruktor pro nastavení vlastností knihy
    public FantasyBook(string bookName, string autor, double price)
    {
        this.BookName = bookName;
        this.Autor = autor;
        this.Price = price;
    }

    // Metoda pro získání hodnoty fantasy knihy
    public double GetValue()
    {
        return this.Price;
    }
}

public class ScifiBook : IBook
{
    // Podobné jako FantasyBook, ale s přidaným počtem stránek
    public string BookName { get; set; }
    public string Autor { get; set; }
    public double Price { get; set; }
    public int PageCount { get; set; }

    public ScifiBook(string bookName, string autor, double price, int pageCount)
    {
        this.BookName = bookName;
        this.Autor = autor;
        this.Price = price;
        this.PageCount = pageCount;
    }

    // Hodnota sci-fi knihy závisí na ceně a počtu stránek
    public double GetValue()
    {
        return this.Price + 10 * (this.PageCount / 100.0);
    }
}

public class DetectiveBook : IBook
{
    // Podobné jako ScifiBook, ale místo počtu stránek má počet obětí
    public string BookName { get; set; }
    public string Autor { get; set; }
    public double Price { get; set; }
    public int NumberOfVictims { get; set; }

    public DetectiveBook(string bookName, string autor, double price, int numberOfVictims)
    {
        this.BookName = bookName;
        this.Autor = autor;
        this.Price = price;
        this.NumberOfVictims = numberOfVictims;
    }

    // Hodnota detektivky závisí na ceně a počtu obětí
    public double GetValue()
    {
        return this.Price + 20 * this.NumberOfVictims;
    }
}

public class Program
{
    // Metoda pro porovnání dvou knih a výběr lepší
    public static IBook BetterBook(IBook book0, IBook book1)
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
            // Pokud mají stejnou hodnotu, vyber náhodně
            Random random = new Random();
            int WinnerBook = random.Next(0, 2);
            if (WinnerBook == 0)
            {
                return book0;
            }
            else
            {
                return book1;
            }
        }
    }

    public static void Main()
    {
        // Vytvoření seznamu knih různých žánrů
        List<IBook> books = new List<IBook>
        {
            new FantasyBook("The Hobbit", "J.R.R. Tolkien", 15.99),
            new ScifiBook("Dune", "Frank Herbert", 20.00, 412),
            new DetectiveBook("The Girl with the Dragon Tattoo", "Stieg Larsson", 25.00, 5)
        };

        // Hledání nejlepší knihy porovnáváním všech knih v seznamu
        IBook bestBook = books[0];
        foreach (var book in books.Skip(1))
        {
            bestBook = BetterBook(bestBook, book);
        }

        // Získání názvu nejlepší knihy podle jejího typu
        string bookName = "";
        if (bestBook is FantasyBook fantasyBook)
            bookName = fantasyBook.BookName;
        else if (bestBook is ScifiBook scifiBook)
            bookName = scifiBook.BookName;
        else if (bestBook is DetectiveBook detectiveBook)
            bookName = detectiveBook.BookName;

        // Výpis nejlepší knihy a její hodnoty
        Console.WriteLine($"Nejlepší kniha je: {bookName} - {bestBook.GetValue():F2}");
    }
}

