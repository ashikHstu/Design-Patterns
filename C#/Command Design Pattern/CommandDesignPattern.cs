using System.Windows.Input;

public interface Icommand
{
    void Execute();
    void Undo();
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
    private Light _light;
    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

// public class TurnOffLightCommand:Icommand
// {
//     private Light _light;
//     public TurnOffLightCommand(Light light)
//     {
//         _light = light;
//     }

//     public void Execute()
//     {
//         _light.TurnOff();
//     }

//     public void Undo()
//     {
//         _light.TurnOn();
//     }
// }

public class RemoteControl
{
    private Icommand _command;
    public void SetCommand(Icommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }

    public void UndoButton()
    {
        _command.Undo();
    }
}

class Program
{
    static void Main()
    {
        Light light = new Light();

        Icommand onCommand = new TurnOnLightCommand(light);
       // Icommand offCommand = new TurnOffLightCommand(light);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(onCommand);
        remote.PressButton();
        remote.UndoButton();
        // remote.SetCommand(offCommand);
        // remote.PressButton();
    }
}