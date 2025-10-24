using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;

public class NotificationRecipient : IRecipient
{
    private readonly INotificationSystem _notification;
    private readonly List<string> _keywords;

    public NotificationRecipient(INotificationSystem notification, IEnumerable<string> keywords)
    {
        _notification = notification ?? throw new ArgumentNullException(nameof(notification));
        _keywords = keywords?.ToList() ?? throw new ArgumentNullException(nameof(keywords));
    }

    public void Receive(Message message)
    {
        if (_keywords.Any(k => message.Body.Contains(k, StringComparison.OrdinalIgnoreCase)))
        {
            _notification.Notify($"Suspicious word found in message: {message.Title}");
        }
    }
}
