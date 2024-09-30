using Library.Common;
using Library.Common.ValueObjects;
using Library.Shapes.Triangles.Exceptions;
using Library.Shapes.Triangles.ValueObjects;
using System.Runtime.CompilerServices;

namespace Library.Shapes.Triangles;

/// <summary>
/// Triangle implementation of <see cref="IShape"/>
/// </summary>
public sealed class Triangle : IShape
{
    public TriangleSide SmallestSide { get; }
    public TriangleSide MiddleSide { get; }
    public TriangleSide BiggestSide { get; }
    public bool IsRight => IsRightInternal();

    public Triangle(TriangleSide a, TriangleSide b, TriangleSide c)
    {
        TriangleSideException.ThrowIfSideException(a, b, c);

        var sides = new List<TriangleSide> { a, b, c }.OrderBy(x => x.Value).ToList();

        SmallestSide = sides[0];
        MiddleSide = sides[1];
        BiggestSide = sides[2];
    }

    public Area GetArea()
    {
        var semiPerimeter = (SmallestSide + MiddleSide + BiggestSide) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - SmallestSide) * (semiPerimeter - MiddleSide) * (semiPerimeter - BiggestSide));
    }

    private bool IsRightInternal()
    {
        return Math.Pow(SmallestSide, 2) + Math.Pow(MiddleSide, 2) == Math.Pow(BiggestSide, 2);
    }
}
