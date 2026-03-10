public sealed class Singleton
{
    public static Singleton instance = null;
    public static readonly Object lockObject = new object();

    private Singleton()
    {
        Console.WriteLine("singleton instance created.");
    }

    public static Singleton GetInstance()
    {
        lock(lockObject)
        {
            if(instance==null)
            {
                instance = new Singleton();
            }
        }
        return instance;
    }
}

class Program
{
    static void Main()
    {
        Singleton obj1 = Singleton.GetInstance();
        Singleton obj2 = Singleton.GetInstance();
        if(obj1 == obj2)
        {
            Console.WriteLine("Both are same objects.");
        }
    }
}