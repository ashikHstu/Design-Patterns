public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

public class SimpleCoffee:ICoffee
{
    public string GetDescription()
    {
        return "Simple coffee,";
    }

    public double GetCost()
    {
        return 5.0;
    }
}

public abstract class CoffeeDecorator:ICoffee
{
    protected ICoffee coffee;
    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee=coffee;
    }

    public virtual String GetDescription()
    {
        return coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return coffee.GetCost();
    }
}

public class MilkDecorator:CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee):base(coffee)
    {
        
    }
    public override string GetDescription()
    {
        return this.coffee.GetDescription()+",Milk";
    }
    public override double GetCost()
    {
        return this.coffee.GetCost()+0.2;
    }
}

public class SugerDecorator:CoffeeDecorator
{
    public SugerDecorator(ICoffee coffee):base(coffee)
    {
        
    }
    
    public override string GetDescription()
    {
        return this.coffee.GetDescription()+", Suger";
    }

    public override double GetCost()
    {
        return this.coffee.GetCost()+0.1;
    }
}

class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine($"Total cost : {coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine($"Total cost : {coffee.GetCost()}");

        coffee = new SugerDecorator(coffee);
        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine($"Total cost : {coffee.GetCost()}");
    }
}