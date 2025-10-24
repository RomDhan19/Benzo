using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class GroupRecipientTests
{
    [Fact]
    public void GroupRecipient_ShouldDeliverToAllRecipients()
    {
        // Arrange
        var user1 = new User("Alice");
        var user2 = new User("Bob");
        var recipient1 = new UserRecipient(user1);
        var recipient2 = new UserRecipient(user2);
        var groupRecipient = new GroupRecipient();
        groupRecipient.AddRecipient(recipient1);
        groupRecipient.AddRecipient(recipient2);
        var message = new Message("Group", "Message", MessageImportance.Normal);

        // Act
        groupRecipient.Receive(message);

        // Assert
        Assert.Single(user1.Messages);
        Assert.Single(user2.Messages);
    }

    [Fact]
    public void GroupRecipient_ShouldHandleFilteredRecipients()
    {
        // Arrange
        var user1 = new User("Alice");
        var user2 = new User("Bob");
        var recipient1 = new UserRecipient(user1, null, MessageImportance.High);
        var recipient2 = new UserRecipient(user2);
        var groupRecipient = new GroupRecipient();
        groupRecipient.AddRecipient(recipient1);
        groupRecipient.AddRecipient(recipient2);
        var message = new Message("Group", "Message", MessageImportance.Low);

        // Act
        groupRecipient.Receive(message);

        // Assert
        Assert.Empty(user1.Messages);
        Assert.Single(user2.Messages);
    }
}