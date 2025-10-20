namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class RouteSegment
{
    public double Length { get; }

    public abstract SegmentType Type { get; }

    protected RouteSegment(double length)
    {
        if (length < 0)
            throw new ArgumentException("Segment length cannot be negative", nameof(length));

        Length = length;
    }

    public abstract TraversalResult Traverse(Train train);
}
