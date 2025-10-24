using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Notifications;

public class SoundNotification : INotificationSystem
{
    private readonly IOutputWriter _outputWriter;

    public SoundNotification(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
    }

    public void Notify(string alertMessage)
    {
        Console.Beep();
        _outputWriter.Write($"SOUND ALERT: {alertMessage}");
    }
}
