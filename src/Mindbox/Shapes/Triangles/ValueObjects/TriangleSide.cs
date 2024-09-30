using Library.Shapes.Triangles.Exceptions;

namespace Library.Shapes.Triangles.ValueObjects;

/// <summary>
/// Side of the <see cref="Triangle"/>, always positive
/// </summary>
public readonly record struct TriangleSide
{
    public double Value { get; }

    public TriangleSide(double value)
    {
        TriangleSizeLengthException.ThrowIfNegativeOrZero(value);

        Value = value;
    }

    public static implicit operator double(TriangleSide side)
    {
        return side.Value;
    }
}