namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class User
{
    public string Name { get; }

    private readonly List<UserMessage> _messages = new();

    public User(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("User name cannot be empty", nameof(name));

        Name = name;
    }

    public void Receive(Message message)
    {
        _messages.Add(new UserMessage(message));
    }

    public void MarkAsRead(Message message)
    {
        UserMessage? userMessage = null;

        foreach (UserMessage msg in _messages)
        {
            if (msg.Message == message)
            {
                userMessage = msg;
                break;
            }
        }

        if (userMessage is null)
            throw new InvalidOperationException("Message not found");

        if (userMessage.IsRead)
            throw new InvalidOperationException("Message already read");

        userMessage.MarkAsRead();
    }

    public IReadOnlyCollection<UserMessage> Messages => _messages.AsReadOnly();
}
