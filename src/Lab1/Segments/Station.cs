using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Segments;

public class Station : RouteSegment
{
    private const double DefaultDepartureSpeed = 10.0;

    public double BoardingTime { get; }

    public double MaxArrivalSpeed { get; }

    public double DepartureSpeed { get; }

    public override SegmentType Type => SegmentType.Station;

    public Station(double boardingTime, double maxArrivalSpeed, double departureSpeed = DefaultDepartureSpeed) : base(0)
    {
        if (boardingTime <= 0)
            throw new ArgumentException("Boarding time must be positive", nameof(boardingTime));

        if (maxArrivalSpeed <= 0)
            throw new ArgumentException("Max arrival speed must be positive", nameof(maxArrivalSpeed));

        if (departureSpeed < 0)
            throw new ArgumentException("Departure speed cannot be negative", nameof(departureSpeed));

        BoardingTime = boardingTime;
        MaxArrivalSpeed = maxArrivalSpeed;
        DepartureSpeed = departureSpeed;
    }

    public override TraversalResult Traverse(Train train)
    {
        if (train is null)
            return TraversalResult.Failure();

        if (train.Speed > MaxArrivalSpeed)
            return TraversalResult.Failure();

        train.Reset();
        train.SetSpeed(DepartureSpeed);

        return TraversalResult.Success(BoardingTime);
    }
}
