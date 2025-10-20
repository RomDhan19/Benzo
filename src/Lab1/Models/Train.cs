namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Train
{
    private const int MaxIterations = 100000;
    private const double DefaultPrecision = 0.1;

    public Train(double mass, double maxForce, double precision = DefaultPrecision)
    {
        if (mass <= 0)
            throw new ArgumentException("Mass must be positive", nameof(mass));

        if (maxForce <= 0)
            throw new ArgumentException("Max force must be positive", nameof(maxForce));

        if (precision <= 0)
            throw new ArgumentException("Precision must be positive", nameof(precision));

        Mass = mass;
        MaxForce = maxForce;
        Precision = precision;
        Speed = 0;
        Acceleration = 0;
    }

    public double Mass { get; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double MaxForce { get; }

    public double Precision { get; }

    public bool ApplyForce(double force)
    {
        if (Math.Abs(force) > MaxForce)
            return false;

        Acceleration = force / Mass;
        return true;
    }

    public TraversalResult CalculateTravelTime(double distance)
    {
        if (distance <= 0)
            return TraversalResult.Failure();

        double currentSpeed = Speed;
        double totalTime = 0;
        double remainingDistance = distance;

        int iterations = 0;
        while (remainingDistance > 0 && iterations < MaxIterations)
        {
            double traveledDistance = (currentSpeed * Precision) + (0.5 * Acceleration * Precision * Precision);

            if ((traveledDistance <= 0) && (Acceleration == 0) && (currentSpeed == 0))
                return TraversalResult.Failure();

            double nextSpeed = currentSpeed + (Acceleration * Precision);

            if (nextSpeed < 0)
                return TraversalResult.Failure();

            remainingDistance -= traveledDistance;
            currentSpeed = nextSpeed;
            totalTime += Precision;
            iterations++;
        }

        if (iterations >= MaxIterations)
            return TraversalResult.Failure();

        Speed = currentSpeed;
        return TraversalResult.Success(totalTime);
    }

    public void Reset()
    {
        Speed = 0;
        Acceleration = 0;
    }

    public void SetSpeed(double speed)
    {
        if (speed < 0)
            throw new ArgumentException("Speed cannot be negative", nameof(speed));
        Speed = speed;
    }
}
