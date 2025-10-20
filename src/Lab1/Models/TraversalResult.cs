namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class TraversalResult
{
    public bool IsSuccess { get; }

    public double Time { get; }

    private TraversalResult(bool isSuccess, double time)
    {
        IsSuccess = isSuccess;
        Time = time;
    }

    public static TraversalResult Success(double time) => new TraversalResult(true, time);

    public static TraversalResult Failure() => new TraversalResult(false, 0);
}
