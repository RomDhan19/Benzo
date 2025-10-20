namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Route
{
    private readonly List<RouteSegment> _segments;

    public double MaxFinalSpeed { get; }

    public IReadOnlyList<RouteSegment> Segments => _segments.AsReadOnly();

    public Route(double maxFinalSpeed)
    {
        if (maxFinalSpeed < 0)
            throw new ArgumentException("Max final speed cannot be negative", nameof(maxFinalSpeed));

        _segments = new List<RouteSegment>();
        MaxFinalSpeed = maxFinalSpeed;
    }

    public void AddSegment(RouteSegment segment)
    {
        ArgumentNullException.ThrowIfNull(segment);

        _segments.Add(segment);
    }

    public RouteResult Simulate(Train train)
    {
        ArgumentNullException.ThrowIfNull(train);

        train.Reset();
        double totalTime = 0;

        foreach (RouteSegment segment in _segments)
        {
            TraversalResult result = segment.Traverse(train);

            if (!result.IsSuccess)
                return RouteResult.Failure($"Failed to traverse {segment.Type} segment");

            totalTime += result.Time;
        }

        if (train.Speed > MaxFinalSpeed)
            return RouteResult.Failure($"Final speed {train.Speed:F2} exceeds maximum allowed {MaxFinalSpeed}");

        return RouteResult.Success(totalTime);
    }
}
