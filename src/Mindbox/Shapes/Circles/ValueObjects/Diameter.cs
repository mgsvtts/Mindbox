using Library.Shapes.Circles.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Shapes.Circles.ValueObjects;

/// <summary>
/// Diameter of the <see cref="Circle"/>
/// </summary>
/// <exception cref="RadiusException">If diameter is less or equal to zero</exception>
public readonly record struct Diameter
{
    public double Value { get; }

    public Diameter(double value)
    {
        RadiusException.ThrowIfNegativeOrZero(value);

        Value = value;
    }

    public Radius ToRadius()
    {
        return new Radius(Value / 2);
    }
}
