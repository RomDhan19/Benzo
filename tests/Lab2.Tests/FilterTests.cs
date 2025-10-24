using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FilterTests
{
    [Fact]
    public void UserRecipient_ShouldIgnoreLowImportanceMessages()
    {
        // Arrange
        var user = new User("Eve");
        ILogger logger = new Mock<ILogger>().Object;
        var recipient = new UserRecipient(user, logger, MessageImportance.High);
        var message = new Message("Note", "Simple", MessageImportance.Low);

        // Act
        recipient.Receive(message);

        // Assert
        Assert.Empty(user.Messages);
    }

    [Fact]
    public void UserRecipient_ShouldAcceptImportantMessages()
    {
        // Arrange
        var user = new User("Charlie");
        ILogger logger = new Mock<ILogger>().Object;
        var recipient = new UserRecipient(user, logger, MessageImportance.Low);
        var message = new Message("Critical", "Attention", MessageImportance.High);

        // Act
        recipient.Receive(message);

        // Assert
        Assert.Single(user.Messages);
    }
}