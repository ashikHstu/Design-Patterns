
public sealed class Singleton
{
    private static Singleton instance = new Singleton();
    private Dictionary<string,Object> data = new Dictionary<string, object>();
    private Singleton(){}
    
    public static Singleton Instance
    {
        get{return instance;}
    }

    public void Set(string key, Object value)
    {
        data[key]=value;
    }

    public Object Get(string key)
    {
        if(data.ContainsKey(key))
            return data[key];
        return null;
    }
}

class Program
{
    static void Main()
    {
        Singleton.Instance.Set("arb","Ashikur Rahman Bhuyain");
        Console.WriteLine(Singleton.Instance.Get("sam"));
        Console.WriteLine(Singleton.Instance.Get("arb"));
        Singleton.Instance.Set("sam", "Afroza Akter Samia.");
        Console.WriteLine(Singleton.Instance.Get("sam"));
    }
}