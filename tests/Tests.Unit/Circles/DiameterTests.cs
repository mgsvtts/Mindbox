using FluentAssertions;
using Library.Shapes.Circles;
using Library.Shapes.Circles.Exceptions;
using Library.Shapes.Circles.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit.Circles;
public sealed class DiameterTests
{
    [Theory]
    [MemberData(nameof(IncorrectDiameterValues))]
    public void Diameter_ThrowsRadiusException_IfRadiusIsNegativeOrZero(double diameter)
    {
        var func = () => new Diameter(diameter);

        func.Should().Throw<RadiusException>();
    }

    public static IEnumerable<object[]> IncorrectDiameterValues()
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
