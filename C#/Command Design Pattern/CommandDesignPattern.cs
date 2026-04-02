public interface Icommand
{
    void Execute();
}

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Turned on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turned off.");
    }
}

public class TurnOnLightCommand:Icommand
{
    private class light;
    public TurnOnLightCommand(Light _light)
    {
        light = _light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}