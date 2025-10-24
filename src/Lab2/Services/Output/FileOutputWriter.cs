using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Output;

public class FileOutputWriter : IOutputWriter
{
    private readonly string _filePath;

    public FileOutputWriter(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public void Write(string content)
    {
        File.AppendAllText(_filePath, content + Environment.NewLine);
    }
}
