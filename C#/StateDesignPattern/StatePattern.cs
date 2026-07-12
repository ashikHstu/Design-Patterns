public class Document
{
    private IDocumentState _state;
    public Document(IDocumentState state)
    {
        _state=state;
    }
    public void SetState(IDocumentState state)
    {
        _state = state;
    }

    public void Publish()
    {
        _state.Publish(this);
    }
}

public interface IDocumentState
{
    void Publish(Document context);
}

public class DraftState:IDocumentState
{
    public void Publish(Document context)
    {
        Console.WriteLine("Moving from draft to moderation state...");
        context.SetState(new ModerationState());
    }
}

public class ModerationState: IDocumentState
{
    public void Publish(Document context)
    {
        Console.WriteLine("Moving from moderation state to published state...");
        context.SetState(new PublishedState());
    }
}

public class PublishedState: IDocumentState
{
    public void Publish(Document context)
    {
        Console.WriteLine("Already published.");
    }
}

class Program
{
    static void Main()
    {
        var doc = new Document(new  DraftState());

        doc.Publish(); // draft to moderation
        doc.Publish(); // moderation to publish
        doc.Publish(); // Already published
    }
}
