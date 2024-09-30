using FluentAssertions;
using Library.Shapes.Triangles.Exceptions;
using Library.Shapes.Triangles.ValueObjects;
using Library.Shapes.Triangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit.Triangles;
public sealed class TriangleSideTests
{

    [Theory]
    [MemberData(nameof(IncorrectTriangleSides))]
    public void Constructor_ThrowsTriangleSizeLengthException_WithIncorrectValues(double side)
    {
        var func = () => new TriangleSide(side);

        func.Should().ThrowExactly<TriangleSizeLengthException>();
    }

    public static IEnumerable<object[]> IncorrectTriangleSides()
    {
        return
        [
            [-1],
            [-2],
            [-3],
            [-0.5],
            [-0.000000001]
        ];
    }
}
