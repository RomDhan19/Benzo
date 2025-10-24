using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Archivers;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages = new();

    public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}
