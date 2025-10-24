using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class UserTests
{
    [Fact]
    public void User_ShouldReceiveMessage()
    {
        // Arrange
        var user = new User("Alice");
        var message = new Message("Hello", "Welcome", MessageImportance.Normal);

        // Act
        user.Receive(message);

        // Assert
        Assert.Single(user.Messages);
        UserMessage userMessage = user.Messages.First();
        Assert.Equal(message, userMessage.Message);
        Assert.False(userMessage.IsRead);
    }

    [Fact]
    public void User_ShouldMarkMessageAsRead()
    {
        // Arrange
        var user = new User("Bob");
        var message = new Message("Test", "Body", MessageImportance.Low);
        user.Receive(message);

        // Act
        user.MarkAsRead(message);

        // Assert
        UserMessage userMessage = user.Messages.First();
        Assert.True(userMessage.IsRead);
    }

    [Fact]
    public void User_ShouldThrowException_WhenMarkingAlreadyReadMessageAsRead()
    {
        // Arrange
        var user = new User("Charlie");
        var message = new Message("Test", "Body", MessageImportance.Normal);
        user.Receive(message);
        user.MarkAsRead(message);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => user.MarkAsRead(message));
    }

    [Fact]
    public void User_ShouldThrowException_WhenMarkingNonExistentMessageAsRead()
    {
        // Arrange
        var user = new User("David");
        var message = new Message("Test", "Body", MessageImportance.Normal);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => user.MarkAsRead(message));
    }
}