using Photoshop.Core.Converters;
using Photoshop.Core.Models;

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