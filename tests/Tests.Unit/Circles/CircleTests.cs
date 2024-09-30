using FluentAssertions;
using Library.Shapes.Circles;
using Library.Shapes.Circles.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit.Circles;
public sealed class CircleTests
{
    [Theory]
    [MemberData(nameof(Radiuses))]
    public void FromRadius_CreatesCircle_ByDefault(Radius radius)
    {
        var circle = Circle.FromRadius(radius);

        circle.Diameter.Value.Should().Be(circle.Radius * 2);
    }

    [Theory]
    [MemberData(nameof(Diameters))]
    public void FromDiameter_CreatesCircle_ByDefault(Diameter diameter)
    {
        var circle = Circle.FromDiameter(diameter);

        circle.Diameter.Value.Should().Be(circle.Radius * 2);
    }

    public static IEnumerable<object[]> Radiuses()
    {
        return
        [
            [new Radius(1)],
            [new Radius(2)],
            [new Radius(5)]
        ];
    }

    public static IEnumerable<object[]> Diameters()
    {
        return
        [
            [new Diameter(1)],
            [new Diameter(2)],
            [new Diameter(5)]
        ];
    }
}
