using Library.Common.Exceptions;
using Library.Shapes.Triangles.ValueObjects;

namespace Library.Shapes.Triangles.Exceptions;

/// <summary>
/// Exception that is thrown if the <see cref="Triangle"/> cannot exist
/// </summary>
public sealed class TriangleSideException : ShapeException
{
    private TriangleSideException(double fistSide, double secondSide, double biggerThan)
        : base($"The sum of any two sides of a triangle must be greater than the third side, but got {fistSide} + {secondSide} > {biggerThan}")
    { }

    public static void ThrowIfSideException(TriangleSide a, TriangleSide b, TriangleSide c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new TriangleSideException(a, b, c);
        }
    }
}