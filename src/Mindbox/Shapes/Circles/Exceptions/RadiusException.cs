using Library.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Shapes.Circles.Exceptions;

/// <summary>
/// Exception that is thrown if the radius of the <see cref="Circle"/> is not positive.
/// </summary>
public sealed class RadiusException : ShapeException
{
    private RadiusException(double radius):base($"Radius of the circle must be positive, but got {radius}")
    {}

    public static void ThrowIfNegativeOrZero(double value)
    {
        if(value <= 0)
        {
            throw new RadiusException(value);
        }
    }
}
