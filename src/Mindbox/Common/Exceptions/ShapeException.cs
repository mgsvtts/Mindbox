using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common.Exceptions;

/// <summary>
/// Base class for all exceptions of the library
/// </summary>
public class ShapeException : Exception
{
    protected ShapeException(string message) : base(message)
    { }
}
