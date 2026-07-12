// Virtual proxy, Lazy loading: Don't load until needed
public interface IImage
{
    void Display();
}

public class RealImage: IImage
{
    private string _fileName;
    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading image from disk: {_fileName}");
    }
    public void Display()
    {
        Console.WriteLine($"Displaying image: {_fileName}");
    }
}

public class ProxyImage: IImage
{
    private RealImage _realImage;
    private string _fileName;
    
    public ProxyImage(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        if(_realImage == null)
        {
            _realImage =  new  RealImage(_fileName);  //  lazy initialization
        }
        _realImage.Display();
    }
}

class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("photo.jpg");

        //Image not loaded yet 
        Console.WriteLine("Image created, not loaded yet.");

        //First call, load iamge
        image.Display();

        // second call, use cached object
        image.Display();
    }
}