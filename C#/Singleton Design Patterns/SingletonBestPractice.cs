public sealed class Singleton
{
    private static readonly Singleton instance = new Singleton();
    private Singleton()
    {
        Console.WriteLine("singleton instance is created.");
    }

    public static Singleton Instance
    {
        get{return instance;}
    }

    public void printMessage()
    {
        Console.WriteLine("Hello from singleton class.");
    }
}

class Program
{
    static void Main()
    {
        Singleton obj= Singleton.Instance;
        obj.printMessage();
    }
}