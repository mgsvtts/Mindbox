namespace Library.Common.Exceptions;

/// <summary>
/// Exception that is thrown if the area of the <see cref="IShape"/> is not positive.
/// </summary>
public sealed class AreaException : ShapeException
{
    private AreaException(double value) : base($"Area of the shape must be positive, but got {value}")
    { }

    public static void ThrowIfNegativeOrZero(double value)
    {
        if (value <= 0)
        {
            throw new AreaException(value);
        }
    }
}