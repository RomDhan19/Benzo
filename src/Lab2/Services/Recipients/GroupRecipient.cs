using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients = new();

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void Receive(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}
