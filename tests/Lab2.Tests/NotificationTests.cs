using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Recipients;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class NotificationTests
{
    [Fact]
    public void NotificationRecipient_ShouldTriggerAlert_OnKeywordFound()
    {
        // Arrange
        var notificationMock = new Mock<INotificationSystem>();
        var keywords = new List<string> { "error", "danger" };
        var recipient = new NotificationRecipient(notificationMock.Object, keywords);
        var message = new Message("Check", "There is an error inside", MessageImportance.Normal);

        // Act
        recipient.Receive(message);

        // Assert
        notificationMock.Verify(n => n.Notify(It.Is<string>(s => s.Contains("Suspicious word found in message"))), Times.Once);
    }

    [Fact]
    public void NotificationRecipient_ShouldNotTriggerAlert_IfNoKeyword()
    {
        // Arrange
        var notificationMock = new Mock<INotificationSystem>();
        var keywords = new List<string> { "alert", "critical" };
        var recipient = new NotificationRecipient(notificationMock.Object, keywords);
        var message = new Message("Update", "Everything is fine", MessageImportance.Normal);

        // Act
        recipient.Receive(message);

        // Assert
        notificationMock.Verify(n => n.Notify(It.IsAny<string>()), Times.Never);
    }
}