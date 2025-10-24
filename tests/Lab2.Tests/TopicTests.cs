using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TopicTests
{
    [Fact]
    public void Topic_ShouldSendMessageToAllRecipients()
    {
        // Arrange
        var topic = new Topic("TestTopic");
        var user1 = new User("Alice");
        var user2 = new User("Bob");
        var recipient1 = new UserRecipient(user1);
        var recipient2 = new UserRecipient(user2);
        topic.AddRecipient(recipient1);
        topic.AddRecipient(recipient2);
        var message = new Message("Topic", "Message", MessageImportance.Normal);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Single(user1.Messages);
        Assert.Single(user2.Messages);
    }

    [Fact]
    public void Topic_ShouldHandleEmptyRecipientsList()
    {
        // Arrange
        var topic = new Topic("EmptyTopic");
        var message = new Message("Topic", "Message", MessageImportance.Normal);

        // Act & Assert
        topic.SendMessage(message);
    }
}