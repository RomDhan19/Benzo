using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ArchiverTests
{
    [Fact]
    public void ArchiverRecipient_ShouldArchiveMessages()
    {
        // Arrange
        var archiver = new InMemoryArchiver();
        var recipient = new ArchiverRecipient(archiver);
        var message = new Message("Save", "Keep this", MessageImportance.Normal);

        // Act
        recipient.Receive(message);

        // Assert
        Assert.Single(archiver.Messages);
    }

    [Fact]
    public void FormattingArchiver_ShouldCallFormatter()
    {
        // Arrange
        var formatterMock = new Mock<IFormatter>();
        var archiver = new FormattingArchiver(formatterMock.Object);
        var message = new Message("Test", "Body", MessageImportance.Normal);

        // Act
        archiver.Archive(message);

        // Assert
        formatterMock.Verify(f => f.Format(message), Times.Once);
    }
}
