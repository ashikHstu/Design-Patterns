public class Projector
{
    public void On() => Console.WriteLine("Projector On");
    public void Off() => Console.WriteLine("Projector Off");
} 

public class DVDPlayer
{
    public void Play() => Console.WriteLine("Playing DVD.");
    public void Stop() => Console.WriteLine("Stopped DVD");
}

public class SoundSystem
{
    public void SetVolume(int level) => Console.WriteLine($"Volume set to : {level}");
}

public class Lights
{
    public void Dim() => Console.WriteLine("Lights dimmed");
    public void On() => Console.WriteLine("Lights on");
}

public class HomeTheaterFacade
{
    private Projector _projector;
    private DVDPlayer _dvdPlayer;
    public SoundSystem _soundSystem;
    public Lights _lights;
    public HomeTheaterFacade(Projector projector, DVDPlayer dvdPlayer, SoundSystem soundSystem, Lights lights)
    {
        _projector = projector;
        _dvdPlayer = dvdPlayer;
        _soundSystem = soundSystem;
        _lights = lights;
    }
    
    public void WatchMovie()
    {
        Console.WriteLine("\nStarting movie...");
        _lights.Dim();
        _projector.On();
        _soundSystem.SetVolume(10);
        _dvdPlayer.Play();
    }

    public void EndMovie()
    {
        Console.WriteLine("\nEnding movie...");

        _dvdPlayer.Stop();
        _projector.Off();
        _lights.On();
    }
}

class Program
{
    static void Main()
    {
        var projector = new Projector();
        var dvd = new DVDPlayer();
        var sound = new SoundSystem();
        var lights = new Lights();

        var homeTheater = new HomeTheaterFacade(projector, dvd, sound, lights);

        homeTheater.WatchMovie();
        homeTheater.EndMovie();
    }
}