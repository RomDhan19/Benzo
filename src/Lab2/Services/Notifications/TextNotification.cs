using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Notifications;

public class TextNotification : INotificationSystem
{
    private readonly IOutputWriter _outputWriter;

    public TextNotification(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
    }

    public void Notify(string alertMessage)
    {
        _outputWriter.Write($"TEXT ALERT: {alertMessage}");
    }
}
