using Photoshop.Core.Converters;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class ConvertMenuItemFactory<TPixel> : IConvertMenuItemFactory<TPixel>
    where TPixel : IPixel
{
    private readonly IEnumerable<IConverter<TPixel>> converters;

    public ConvertMenuItemFactory(IEnumerable<IConverter<TPixel>> converters)
    {
        this.converters = converters;
    }

    public IEnumerable<ConvertMenuItem<TPixel>> Create() //todo плохая завязка на имя
    {
        return converters.Select(converter => new { converter, name = converter.GetType().Name })
                         .Select(t => new ConvertMenuItem<TPixel>(t.converter,
                                                                  $"{t.name.Substring(3, t.name.Length - 12)} Filter"));
    }
}