namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public enum MessageImportance
{
    Low = 1,
    Normal = 2,
    High = 3,
    Critical = 4,
}

public class Message
{
    public string Title { get; }

    public string Body { get; }

    public MessageImportance Importance { get; }

    public Message(string title, string body, MessageImportance importance)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Message title cannot be empty", nameof(title));

        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentException("Message body cannot be empty", nameof(body));

        Title = title;
        Body = body;
        Importance = importance;
    }

    public override string ToString() =>
        $"# {Title}\n\n{Body}\n\n**Importance:** {Importance}";
}
