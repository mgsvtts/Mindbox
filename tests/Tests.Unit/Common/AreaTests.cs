using FluentAssertions;
using Library.Common.Exceptions;
using Library.Common.ValueObjects;
using Library.Shapes.Triangles.Exceptions;
using Library.Shapes.Triangles.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit.Common;
public sealed class AreaTests
{
    [Theory]
    [MemberData(nameof(IncorrectAreas))]
    public void Constructor_ThrowsAreaException_WithIncorrectValues(double area)
    {
        var func = () => new Area(area);

        func.Should().ThrowExactly<AreaException>();
    }

    public static IEnumerable<object[]> IncorrectAreas()
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
