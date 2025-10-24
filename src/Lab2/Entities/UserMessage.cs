namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class UserMessage
{
    public Message Message { get; }

    public bool IsRead { get; private set; }

    public UserMessage(Message message)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }

    public void MarkAsRead() => IsRead = true;
}
