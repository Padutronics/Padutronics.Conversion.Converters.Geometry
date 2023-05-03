using Padutronics.Formatting.Geometry;
using Padutronics.Geometry;
using System.Numerics;

namespace Padutronics.Conversion.Converters.Geometry;

public sealed class Point2ToStringConverter<T> : PointToStringConverter<T>, IConverter<Point2<T>, string>
    where T : INumber<T>
{
    public Point2ToStringConverter(PointFormatOptions formatOptions, IConverter<T, string> valueConverter) :
        base(formatOptions, valueConverter)
    {
    }

    public string Convert(Point2<T> value)
    {
        return Convert(new[]
        {
            new PointComponentDescription<T>(nameof(value.X), value.X),
            new PointComponentDescription<T>(nameof(value.Y), value.Y)
        });
    }
}