using Photoshop.Core.Converters;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class ConvertMenuItem<TPixel>
    where TPixel : IPixel
{
    public IConverter<TPixel> Converter { get; }
    public string MenuName { get; }

    public ConvertMenuItem(IConverter<TPixel> converter, string menuName)
    {
        Converter = converter;
        MenuName = menuName;
    }
}