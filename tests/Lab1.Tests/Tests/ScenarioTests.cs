using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class ScenarioTests
{
    [Fact]
    public void Scenario1_ForcePathAcceleratingToAllowedSpeedThenRegularPath_ShouldSucceed()
    {
        var train = new Train(mass: 1000, maxForce: 5000);
        var route = new Route(maxFinalSpeed: 50);

        route.AddSegment(new ForceMagneticPath(length: 200, force: 2000));
        route.AddSegment(new RegularMagneticPath(length: 100));

        RouteResult result = route.Simulate(train);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Scenario2_ForcePathAcceleratingBeyondRouteLimitThenRegularPath_ShouldFail()
    {
        var train = new Train(mass: 1000, maxForce: 10000);
        var route = new Route(maxFinalSpeed: 30);

        route.AddSegment(new ForceMagneticPath(length: 100, force: 8000));
        route.AddSegment(new RegularMagneticPath(length: 200));

        RouteResult result = route.Simulate(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Scenario3_ForcePathToAllowedSpeedWithStation_ShouldSucceed()
    {
        var train = new Train(mass: 1000, maxForce: 5000);
        var route = new Route(maxFinalSpeed: 50);

        route.AddSegment(new ForceMagneticPath(length: 150, force: 2000));
        route.AddSegment(new RegularMagneticPath(length: 100));
        route.AddSegment(new Station(boardingTime: 30, maxArrivalSpeed: 40, departureSpeed: 15));
        route.AddSegment(new RegularMagneticPath(length: 100));

        RouteResult result = route.Simulate(train);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Scenario4_ForcePathBeyondStationSpeedLimit_ShouldFail()
    {
        // Arrange
        var train = new Train(mass: 1000, maxForce: 8000);
        var route = new Route(maxFinalSpeed: 50);

        route.AddSegment(new ForceMagneticPath(length: 200, force: 7000));
        route.AddSegment(new Station(boardingTime: 30, maxArrivalSpeed: 40));

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Scenario5_ForcePathBeyondRouteSpeedButWithinStationSpeed_ShouldFail()
    {
        var train = new Train(mass: 1000, maxForce: 8000);
        var route = new Route(maxFinalSpeed: 30);

        route.AddSegment(new ForceMagneticPath(length: 100, force: 6000));
        route.AddSegment(new RegularMagneticPath(length: 200));
        route.AddSegment(new Station(boardingTime: 30, maxArrivalSpeed: 50, departureSpeed: 10));
        route.AddSegment(new RegularMagneticPath(length: 150));

        RouteResult result = route.Simulate(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Scenario6_ComplexPathWithAccelerationAndDeceleration_ShouldSucceed()
    {
        var train = new Train(mass: 1000, maxForce: 10000);
        var route = new Route(maxFinalSpeed: 40);

        route.AddSegment(new ForceMagneticPath(length: 100, force: 4000));
        route.AddSegment(new RegularMagneticPath(length: 50));
        route.AddSegment(new ForceMagneticPath(length: 100, force: -3000));
        route.AddSegment(new Station(boardingTime: 30, maxArrivalSpeed: 35, departureSpeed: 15));
        route.AddSegment(new RegularMagneticPath(length: 80));
        route.AddSegment(new ForceMagneticPath(length: 80, force: 3000));
        route.AddSegment(new RegularMagneticPath(length: 60));
        route.AddSegment(new ForceMagneticPath(length: 70, force: -2000));

        RouteResult result = route.Simulate(train);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Scenario7_RegularPathOnly_ShouldFail()
    {
        var train = new Train(mass: 1000, maxForce: 5000);
        var route = new Route(maxFinalSpeed: 50);

        route.AddSegment(new RegularMagneticPath(length: 100));

        RouteResult result = route.Simulate(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Scenario8_ForcePathWithPositiveThenDoubleNegativeForce_ShouldFail()
    {
        var train = new Train(mass: 1000, maxForce: 5000);
        var route = new Route(maxFinalSpeed: 50);

        const double lengthX = 100;
        const double forceY = 3000;

        route.AddSegment(new ForceMagneticPath(length: lengthX, force: forceY));
        route.AddSegment(new ForceMagneticPath(length: lengthX, force: -2 * forceY));

        RouteResult result = route.Simulate(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Train_ReachesHighSpeed_WithLongForcePath()
    {
        // Arrange
        var train = new Train(1000, 8000);
        train.ApplyForce(4000);

        // Act
        TraversalResult result = train.CalculateTravelTime(200);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(train.Speed > 40, $"Train speed should be > 40, but is {train.Speed}");
    }
}


