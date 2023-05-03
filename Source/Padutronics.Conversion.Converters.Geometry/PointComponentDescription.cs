namespace Padutronics.Conversion.Converters.Geometry;

internal sealed class PointComponentDescription<T>
{
    public PointComponentDescription(string name, T value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }

    public T Value { get; }
}