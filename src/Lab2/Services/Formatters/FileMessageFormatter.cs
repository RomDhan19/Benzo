using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Formatters;

public class FileMessageFormatter : IFormatter
{
    private readonly IOutputWriter _outputWriter;

    public FileMessageFormatter(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
    }

    public string Format(Message message)
    {
        string formatted = $"# {message.Title}\n\n{message.Body}\n\n**Importance:** {message.Importance}";
        _outputWriter.Write(formatted);

        return formatted;
    }
}
