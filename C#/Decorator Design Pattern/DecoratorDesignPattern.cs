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

    public bool GetCost()
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

    public String GetDescription()
    {
        return coffee.GetDescription();
    }

    public double GetCost()
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
        return this.coffee.GetDescription+",Milk";
    }
    public override double GetCost()
    {
        return this.coffee.GetCost+0.2;
    }
}