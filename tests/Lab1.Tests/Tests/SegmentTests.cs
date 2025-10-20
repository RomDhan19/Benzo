using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class SegmentTests
{
    [Fact]
    public void RegularMagneticPath_Traverse_ShouldSucceed_WithMovingTrain()
    {
        var train = new Train(1000, 5000);
        train.ApplyForce(2000);
        var regularPath = new RegularMagneticPath(100);

        TraversalResult result = regularPath.Traverse(train);

        Assert.True(result.IsSuccess);
        Assert.True(result.Time > 0);
    }

    [Fact]
    public void ForceMagneticPath_Traverse_ShouldApplyForceCorrectly()
    {
        var train = new Train(1000, 5000);
        var forcePath = new ForceMagneticPath(100, 2000);

        TraversalResult result = forcePath.Traverse(train);

        Assert.True(result.IsSuccess);
        Assert.True(result.Time > 0);
        Assert.Equal(2, train.Acceleration);
    }

    [Fact]
    public void Station_Traverse_ShouldSucceed_WhenSpeedWithinLimit()
    {
        var train = new Train(1000, 5000);
        train.ApplyForce(1000);
        train.CalculateTravelTime(50);
        var station = new Station(boardingTime: 30, maxArrivalSpeed: 40);

        TraversalResult result = station.Traverse(train);

        Assert.True(result.IsSuccess);
        Assert.Equal(30, result.Time);
        Assert.Equal(10, train.Speed);
    }

    [Fact]
    public void Station_Traverse_ShouldFail_WhenSpeedExceedsMaxArrivalSpeed()
    {
        var train = new Train(1000, 5000);
        train.ApplyForce(5000);
        train.CalculateTravelTime(50);
        var station = new Station(boardingTime: 30, maxArrivalSpeed: 10);

        TraversalResult result = station.Traverse(train);

        Assert.False(result.IsSuccess);
    }
}


