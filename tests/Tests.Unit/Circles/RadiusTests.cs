using FluentAssertions;
using Library.Shapes.Circles.Exceptions;
using Library.Shapes.Circles.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit.Circles;
public sealed class RadiusTests
{
    [Theory]
    [MemberData(nameof(IncorrectRadiusValues))]
    public void Radius_ThrowsRadiusException_IfValueIsNegativeOrZero(double radius)
    {
        var func = () => new Radius(radius);

        func.Should().Throw<RadiusException>();
    }

    public static IEnumerable<object[]> IncorrectRadiusValues()
    {
        return
        [
            [0],
            [-1],
            [-100],
            [-0.000001]
        ];
    }
}
