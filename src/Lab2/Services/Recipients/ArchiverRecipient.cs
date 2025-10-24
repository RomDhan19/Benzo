using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;

public class ArchiverRecipient : IRecipient
{
    private readonly IArchiver _archiver;

    public ArchiverRecipient(IArchiver archiver)
    {
        _archiver = archiver ?? throw new ArgumentNullException(nameof(archiver));
    }

    public void Receive(Message message)
    {
        _archiver.Archive(message);
    }
}
