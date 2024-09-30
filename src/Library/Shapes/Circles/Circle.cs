using Library.Common;
using Library.Common.ValueObjects;
using Library.Shapes.Circles.Exceptions;
using Library.Shapes.Circles.ValueObjects;

namespace Library.Shapes.Circles;

/// <summary>
/// Circle implementation of <see cref="IShape"/>
/// </summary>
public sealed class Circle : IShape
{
    /// <summary>
    /// Radius of the <see cref="Circle"/>
    /// </summary>
    public Radius Radius { get; }

    /// <summary>
    /// Diameter of the <see cref="Circle"/>, half of the <see cref="Radius"/>
    /// </summary>
    public Diameter Diameter => Radius.ToDiameter();

    private Circle(Radius radius)
    {
        Radius = radius;
    }

    /// <summary>
    /// Creates the <see cref="Circle"/> from <see cref="ValueObjects.Radius"/>
    /// </summary>
    /// <param name="radius">radius to create circle</param>
    /// <returns><see cref="Circle"/></returns>
    public static Circle FromRadius(Radius radius)
    {
        return new Circle(radius);
    }

    /// <summary>
    /// Creates the <see cref="Circle"/> from <see cref="ValueObjects.Diameter"/>
    /// </summary>
    /// <param name="diameter">diameter to create circle</param>
    /// <returns><see cref="Circle"/></returns>
    public static Circle FromDiameter(Diameter diameter)
    {
        return new Circle(diameter.ToRadius());
    }

    public Area GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
