namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class RouteResult
{
    public bool IsSuccess { get; }

    public double TotalTime { get; }

    public string? FailureReason { get; }

    private RouteResult(bool isSuccess, double totalTime, string? failureReason = null)
    {
        IsSuccess = isSuccess;
        TotalTime = totalTime;
        FailureReason = failureReason;
    }

    public static RouteResult Success(double totalTime) => new RouteResult(true, totalTime);

    public static RouteResult Failure(string reason) => new RouteResult(false, 0, reason);
}
