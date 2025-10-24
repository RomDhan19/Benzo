using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;

public class UserRecipient : IRecipient
{
    private readonly User _user;
    private readonly ILogger? _logger;
    private readonly MessageImportance? _minImportance;

    public UserRecipient(User user, ILogger? logger = null, MessageImportance? minImportance = null)
    {
        _user = user;
        _logger = logger;
        _minImportance = minImportance;
    }

    public void Receive(Message message)
    {
        if (_minImportance.HasValue && message.Importance < _minImportance)
            return;

        _user.Receive(message);
        _logger?.Log($"Message delivered to {_user.Name}: {message.Title}");
    }
}
