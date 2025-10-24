using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Output;

public class ConsoleOutputWriter : IOutputWriter
{
    public void Write(string content)
    {
        Console.WriteLine(content);
    }
}
