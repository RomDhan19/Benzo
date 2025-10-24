using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Archivers;

public class FormattingArchiver : IArchiver
{
    private readonly IFormatter _formatter;

    public FormattingArchiver(IFormatter formatter)
    {
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    public void Archive(Message message)
    {
        string formattedMessage = _formatter.Format(message);
    }
}
