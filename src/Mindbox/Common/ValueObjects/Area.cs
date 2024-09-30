using Library.Common.Exceptions;

namespace Library.Common.ValueObjects;


/// <summary>
/// Area of the <see cref="IShape"/>
/// </summary>
/// <exception cref="AreaException">Throws if area value is less or equal to zero</exception>
public readonly record struct Area
{
    public double Value { get; }
    public Area(double value)
    {
        AreaException.ThrowIfNegativeOrZero(value);

        Value = value;
    }

    public static implicit operator Area(double value)
    {
        return new Area(value);
    }
}
