using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Segments;

public class ForceMagneticPath : RouteSegment
{
    public double Force { get; }

    public override SegmentType Type => SegmentType.Force;

    public ForceMagneticPath(double length, double force) : base(length)
    {
        Force = force;
    }

    public override TraversalResult Traverse(Train train)
    {
        if (train is null)
            return TraversalResult.Failure();

        if (!train.ApplyForce(Force))
            return TraversalResult.Failure();

        return train.CalculateTravelTime(Length);
    }
}