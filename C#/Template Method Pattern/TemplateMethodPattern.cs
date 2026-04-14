using System.ComponentModel;

public abstract class Beverage
{
    // Template Method (defines the algorithm)
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    protected void BoilWater()
    {
        Console.WriteLine("Boiling Water...");
    }

    protected abstract void Brew(); // must override

    protected void PourInCup()
    {
        Console.WriteLine("Pouring into cup...");
    }

    protected abstract void AddCondiments(); // must override
}

public class Tea:Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon...");
    }
}

public class Coffee:Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Brewing the coffee...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding suger and milk...");
    }
}

class Program
{
    static void Main()
    {
        Beverage tea = new Tea();
        Console.WriteLine("Making Tea:");
        tea.PrepareRecipe();

        Console.WriteLine();

        Beverage coffee = new Coffee();
        Console.WriteLine("Making coffee: ");
        coffee.PrepareRecipe();
    }
}