using Library.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Shapes.Triangles.Exceptions;

/// <summary>
/// Exception that is thrown if the side of the <see cref="Triangle"/> is not positive.
/// </summary>
public sealed class TriangleSizeLengthException : ShapeException
{
    private TriangleSizeLengthException(double value) : base($"Side of the triangle must be positive, but got {value}")
    { }

    public static void ThrowIfNegativeOrZero(double value)
    {
        if (value <= 0)
        {
            throw new TriangleSizeLengthException(value);
        }
    }
}

