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
    private class _light;
    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

public class TurnOffLightCommand:Icommand
{
    private Light _light;
    public TurnOffLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}