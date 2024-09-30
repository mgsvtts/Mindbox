using Library.Shapes.Circles.Exceptions;

namespace Library.Shapes.Circles.ValueObjects;

/// <summary>
/// Radius of the <see cref="Circle"/>
/// </summary>
/// <exception cref="RadiusException">If radius is less or equal to zero</exception>
public readonly record struct Radius
{
    public double Value { get; }

    public Radius(double value)
    {
        RadiusException.ThrowIfNegativeOrZero(value);

        Value = value;
    }

    public Diameter ToDiameter()
    {
        return new Diameter(Value * 2);
    }

    public static implicit operator double(Radius radius)
    {
        return radius.Value;
    }
}
