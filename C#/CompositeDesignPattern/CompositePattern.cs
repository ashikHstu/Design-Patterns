using System.Collections.Generic;

public abstract class FileSystemItem
{
    public string Name { get; set; }

    public FileSystemItem(string name)
    {
        Name = name;
    }

    public abstract int GetSize();
}

public class File : FileSystemItem
{
    private int _size;

    public File(string name, int size) : base(name)
    {
        _size = size;
    }

    public override int GetSize()
    {
        return _size;
    }
}

public class Folder : FileSystemItem
{
    private List<FileSystemItem> _items = new List<FileSystemItem>();

    public Folder(string name) : base(name) { }

    public void Add(FileSystemItem item)
    {
        _items.Add(item);
    }

    public void Remove(FileSystemItem item)
    {
        _items.Remove(item);
    }

    public override int GetSize()
    {
        int totalSize = 0;

        foreach (var item in _items)
        {
            totalSize += item.GetSize(); // uniform call
        }

        return totalSize;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var file1 = new File("File1.txt", 10);
        var file2 = new File("File2.txt", 20);

        var folder1 = new Folder("Folder1");
        folder1.Add(file1);
        folder1.Add(file2);

        var file3 = new File("File3.txt", 30);

        var root = new Folder("Root");
        root.Add(folder1);
        root.Add(file3);

        Console.WriteLine($"Total Size: {root.GetSize()}");
    }
}