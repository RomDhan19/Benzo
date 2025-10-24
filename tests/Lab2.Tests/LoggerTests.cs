using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LoggerTests
{
    [Fact]
    public void UserRecipient_ShouldLogMessageDelivery()
    {
        // Arrange
        var user = new User("Dmitry");
        var loggerMock = new Mock<ILogger>();
        var recipient = new UserRecipient(user, loggerMock.Object);
        var message = new Message("Hi", "Body", MessageImportance.Normal);

        // Act
        recipient.Receive(message);

        // Assert
        loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains("Dmitry"))), Times.Once);
    }
}