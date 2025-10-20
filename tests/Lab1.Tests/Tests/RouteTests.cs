using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class RouteTests
{
    [Fact]
    public void Route_Simulate_ShouldSucceed_WithValidSegments()
    {
        var train = new Train(1000, 5000);
        var route = new Route(maxFinalSpeed: 50);

        route.AddSegment(new ForceMagneticPath(100, 2000));
        route.AddSegment(new RegularMagneticPath(200));
        route.AddSegment(new Station(30, 40, 10));
        route.AddSegment(new RegularMagneticPath(150));

        RouteResult result = route.Simulate(train);

        Assert.True(result.IsSuccess);
        Assert.True(result.TotalTime > 0);
    }

    [Fact]
    public void Route_Simulate_ShouldFail_WhenFinalSpeedExceedsLimit()
    {
        var train = new Train(1000, 5000);
        var route = new Route(maxFinalSpeed: 10);

        route.AddSegment(new ForceMagneticPath(100, 4000));
        route.AddSegment(new RegularMagneticPath(200));

        RouteResult result = route.Simulate(train);

        Assert.False(result.IsSuccess);
        Assert.Contains("Final speed", result.FailureReason, StringComparison.Ordinal);
    }

    [Fact]
    public void Route_AddSegment_ShouldAddSegment_WhenValidSegmentProvided()
    {
        var route = new Route(maxFinalSpeed: 50);
        var segment = new RegularMagneticPath(100);

        route.AddSegment(segment);

        Assert.Single(route.Segments);
        Assert.Equal(segment, route.Segments[0]);
    }
}


