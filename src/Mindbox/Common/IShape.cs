using Library.Common.ValueObjects;

namespace Library.Common;


/// <summary>
/// Interface for all shapes
/// </summary>
public interface IShape
{
    /// <summary>
    /// Get area of the implementing shape
    /// </summary>
    /// <returns><see cref="Area"/></returns>
    public Area GetArea();
}
