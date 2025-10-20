using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class TrainTests
{
    [Fact]
    public void Constructor_ShouldInitialize_WithValidParameters()
    {
        var train = new Train(1000, 5000, 0.1);

        Assert.Equal(1000, train.Mass);
        Assert.Equal(5000, train.MaxForce);
        Assert.Equal(0.1, train.Precision);
        Assert.Equal(0, train.Speed);
        Assert.Equal(0, train.Acceleration);
    }

    [Fact]
    public void ApplyForce_ShouldReturnTrue_WhenForceWithinLimit()
    {
        var train = new Train(1000, 5000);

        bool result = train.ApplyForce(3000);

        Assert.True(result);
        Assert.Equal(3, train.Acceleration);
    }

    [Fact]
    public void ApplyForce_ShouldReturnFalse_WhenForceExceedsMaxForce()
    {
        var train = new Train(1000, 5000);

        bool result = train.ApplyForce(6000);

        Assert.False(result);
        Assert.Equal(0, train.Acceleration);
    }

    [Fact]
    public void CalculateTravelTime_ShouldSucceed_WithPositiveAcceleration()
    {
        var train = new Train(1000, 5000);
        train.ApplyForce(1000);

        TraversalResult result = train.CalculateTravelTime(100);

        Assert.True(result.IsSuccess);
        Assert.True(result.Time > 0);
    }

    [Fact]
    public void CalculateTravelTime_ShouldFail_WithNoMotion()
    {
        var train = new Train(1000, 5000);

        TraversalResult result = train.CalculateTravelTime(100);

        Assert.False(result.IsSuccess);
    }
}


