using Photoshop.Core.Converters;

namespace Photoshop.Visualization;

public class ConvertMenuItem
{
    public IConverter Converter { get; }
    public string MenuName { get; }

    public ConvertMenuItem(IConverter converter, string menuName)
    {
        Converter = converter;
        MenuName = menuName;
    }
}