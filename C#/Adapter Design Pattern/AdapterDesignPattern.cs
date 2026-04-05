public interface INotification
{
    void Send(string message);
}

public class EmailService
{
    public void SendEmail(string content)
    {
        Console.WriteLine("Email content: "+ content);
    }
}

public class EmailAdapter:INotification
{
    private EmailService _emailService;
    public EmailAdapter(EmailService emailService)
    {
        _emailService = emailService;
    }

    public void Send(string message)
    {
        _emailService.SendEmail(message);
    }
}
class Program
{
    static void Main()
    {
        EmailService emailService = new EmailService();

        INotification notification = new EmailAdapter(emailService);
        notification.Send("First email");
    }
}