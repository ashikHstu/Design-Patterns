public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

public class BookCollection : IAggregate<string>
{
    private List<string> books = new List<string>();

    public void AddBook(string book)
    {
        books.Add(book);
    }

    public string GetBook(int index)
    {
        return books[index];
    }

    public int Count => books.Count;

    public IIterator<string> CreateIterator()
    {
        return new BookIterator(this);
    }
}

public class BookIterator : IIterator<string>
{
    private BookCollection collection;
    private int position = 0;

    public BookIterator(BookCollection collection)
    {
        this.collection = collection;
    }

    public bool HasNext()
    {
        return position < collection.Count;
    }

    public string Next()
    {
        return collection.GetBook(position++);
    }
}

class Program
{
    static void Main()
    {
        BookCollection books = new BookCollection();

        books.AddBook("Clean Code");
        books.AddBook("Design Patterns");
        books.AddBook("Refactoring");

        IIterator<string> iterator = books.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}