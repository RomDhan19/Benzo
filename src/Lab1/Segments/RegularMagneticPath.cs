using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Segments;

public class RegularMagneticPath : RouteSegment
{
    public override SegmentType Type => SegmentType.Regular;

    public RegularMagneticPath(double length) : base(length)
    {
    }

    public override TraversalResult Traverse(Train train)
    {
        if (train is null)
            return TraversalResult.Failure();

        return train.CalculateTravelTime(Length);
    }
}