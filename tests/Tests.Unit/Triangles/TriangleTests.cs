using FluentAssertions;
using Library.Common.ValueObjects;
using Library.Shapes;
using Library.Shapes.Triangles;
using Library.Shapes.Triangles.Exceptions;
using Library.Shapes.Triangles.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests.Unit.Triangles;

public sealed class TriangleTests
{
    [Theory]
    [MemberData(nameof(IncorrectTriangleSides))]
    public void Constructor_ThrowsTriangleSideException_WithIncorrectSides(TriangleSide a, TriangleSide b, TriangleSide c)
    {
        var func = () => new Triangle(a, b, c);

        func.Should().ThrowExactly<TriangleSideException>();
    }

    [Theory]
    [MemberData(nameof(CorrectTriangleSides))]
    public void Constructor_SetsSidesCorrectly_WithCorrectSides(TriangleSide a, TriangleSide b, TriangleSide c)
    {
        var triangle = new Triangle(a, b, c);

        triangle.SmallestSide.Value.Should().BeLessThanOrEqualTo(triangle.MiddleSide).And.BeLessThanOrEqualTo(triangle.BiggestSide);
        triangle.MiddleSide.Value.Should().BeLessThanOrEqualTo(triangle.BiggestSide).And.BeGreaterThanOrEqualTo(triangle.SmallestSide);
        triangle.BiggestSide.Value.Should().BeGreaterThanOrEqualTo(triangle.SmallestSide).And.BeGreaterThanOrEqualTo(triangle.MiddleSide);
    }

    [Theory]
    [MemberData(nameof(AreaSides))]
    public void GetArea_CalculatesAreaCorrectly_ByDefault(TriangleSide a, TriangleSide b, TriangleSide c, Area area)
    {
        var triangle = new Triangle(a, b, c);

        triangle.GetArea().Should().Be(area);
    }

    [Theory]
    [MemberData(nameof(RightTriangles))]
    public void IsRight_ReturnsTrue_IfTriangleIsRight(TriangleSide a, TriangleSide b, TriangleSide c)
    {
        var triangle = new Triangle(a, b, c);

        triangle.IsRight.Should().BeTrue();
    }

    public static IEnumerable<object[]> IncorrectTriangleSides()
    {
        return
        [
            [new TriangleSide(1), new TriangleSide(1),new TriangleSide(3)],
            [new TriangleSide(100), new TriangleSide(5), new TriangleSide(3)],
            [new TriangleSide(10.10), new TriangleSide(20.20), new TriangleSide(30.30)],
        ];
    }

    public static IEnumerable<object[]> CorrectTriangleSides()
    {
        return
        [
            [new TriangleSide(1), new TriangleSide(1), new TriangleSide(1)],
            [new TriangleSide(3), new TriangleSide(4),new TriangleSide(5)],
            [new TriangleSide(5), new TriangleSide(5), new TriangleSide(8)],
            [new TriangleSide(6), new TriangleSide(8), new TriangleSide(10)],
            [new TriangleSide(7), new TriangleSide(10), new TriangleSide(12)],
            [new TriangleSide(10), new TriangleSide(15), new TriangleSide(20)]
        ];
    }

    public static IEnumerable<object[]> AreaSides()
    {
        return
        [
            [new TriangleSide(3), new TriangleSide(4),new TriangleSide(5), new Area(6)],
            [new TriangleSide(5),new TriangleSide(12),new TriangleSide(13), new Area(30)],
            [new TriangleSide(8),new TriangleSide(15),new TriangleSide(17),new Area(60)]
        ];
    }

    public static IEnumerable<object[]> RightTriangles()
    {
        return
        [
            [new TriangleSide(3),new TriangleSide(4),new TriangleSide(5)],
            [new TriangleSide(5),new TriangleSide(12),new TriangleSide(13)],
            [new TriangleSide(9),new TriangleSide(40),new TriangleSide(41)],
            [new TriangleSide(10),new TriangleSide(24),new TriangleSide(26)],
            [new TriangleSide(20),new TriangleSide(21),new TriangleSide(29)]
        ];
    }
}