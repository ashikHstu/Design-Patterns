public interface IObserver
{
    void Update(string messgae);
}
public interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify();
}

public class YoutubeChannel:ISubject
{
    private string videoTitle;
    private List<IObserver> subscribers= new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        subscribers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        subscribers.Remove(observer);
    }

    public void UploadVideo(string title)
    {
        videoTitle=title;
        Notify();
    }

    public void Notify()
    {
        foreach(var subscriber in subscribers)
        {
            subscriber.Update(videoTitle);
        }
    }
}

public class Subscriber:IObserver
{
    private string SubscriberName;

    public Subscriber(string name)
    {
        SubscriberName=name;
    }

    public void Update(string title)
    {
        Console.WriteLine($"User : {SubscriberName} received notification title: {title}");
    }
}

class Program
{
    static void Main()
    {
        YoutubeChannel channel = new YoutubeChannel();

        Subscriber subscriber1 = new Subscriber("Ashik");
        Subscriber subscriber2 = new Subscriber("Samia");

        channel.Subscribe(subscriber1);
        channel.Subscribe(subscriber2);

        channel.UploadVideo("First video.");
        channel.Unsubscribe(subscriber2);

        channel.UploadVideo("Second video.");
    }
}