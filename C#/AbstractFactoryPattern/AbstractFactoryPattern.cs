using System;
public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Render();
}

public class LightButton:IButton
{
    public void Render()
    {
        Console.WriteLine("Light Button rendered.");
    }
}

public class LightCheckbox:ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Light checkbox rendered.");
    }
}

public class DarkButton:IButton
{
    public void Render()
    {
        Console.WriteLine("Dark button rendered.");
    }
}

public class DarkCheckbox:ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Dark checkbox rendered.");
    }
}

public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class LightThemeFactory:IUIFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new LightCheckbox();
    }
}

public class DarkThemeFactory:IUIFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new DarkCheckbox();
    }
}

class Program
{
    static void Main()
    {
        IUIFactory factory;
        factory = new LightThemeFactory();
        
        IButton button = factory.CreateButton();
        ICheckbox checkbox = factory.CreateCheckbox();

        button.Render();
        checkbox.Render();
    }
}
