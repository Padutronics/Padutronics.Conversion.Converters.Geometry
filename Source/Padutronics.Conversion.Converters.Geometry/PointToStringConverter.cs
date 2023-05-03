using Padutronics.Formatting.Geometry;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Padutronics.Conversion.Converters.Geometry;

public abstract class PointToStringConverter<T>
{
    private readonly PointFormatOptions formatOptions;
    private readonly IConverter<T, string> valueConverter;

    protected PointToStringConverter(PointFormatOptions formatOptions, IConverter<T, string> valueConverter)
    {
        this.formatOptions = formatOptions;
        this.valueConverter = valueConverter;
    }

    protected private string Convert(IEnumerable<PointComponentDescription<T>> componentDescriptions)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(formatOptions.OpeningCap);
        if (formatOptions.InsertSpaceWithinCaps)
        {
            stringBuilder.Append(' ');
        }

        stringBuilder.Append(string.Join(GetDelimiter(), componentDescriptions.Select(componentDescription => GetComponent(componentDescription))));

        if (formatOptions.InsertSpaceWithinCaps)
        {
            stringBuilder.Append(' ');
        }
        stringBuilder.Append(formatOptions.ClosingCap);

        return stringBuilder.ToString();
    }

    private string GetComponent(PointComponentDescription<T> componentDescription)
    {
        string value = valueConverter.Convert(componentDescription.Value);

        var stringBuilder = new StringBuilder();
        if (formatOptions.ShowComponentName)
        {
            stringBuilder.Append(componentDescription.Name);
            if (formatOptions.InsertSpaceBeforeComponentNameAndValueDelimiter)
            {
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(formatOptions.ComponentNameAndValueDelimiter);
            if (formatOptions.InsertSpaceAfterComponentNameAndValueDelimiter)
            {
                stringBuilder.Append(' ');
            }
        }
        stringBuilder.Append(value);

        return stringBuilder.ToString();
    }

    private string GetDelimiter()
    {
        var stringBuilder = new StringBuilder();
        if (formatOptions.InsertSpaceBeforeComponentDelimiter)
        {
            stringBuilder.Append(' ');
        }
        stringBuilder.Append(formatOptions.ComponentDelimiter);
        if (formatOptions.InsertSpaceAfterComponentDelimiter)
        {
            stringBuilder.Append(' ');
        }

        return stringBuilder.ToString();
    }
}