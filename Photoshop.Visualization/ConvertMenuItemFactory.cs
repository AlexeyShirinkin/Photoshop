using Photoshop.Core.Converters;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class ConvertMenuItemFactory : IConvertMenuItemFactory
{
    private readonly IEnumerable<IConverter> converters;

    public ConvertMenuItemFactory(IEnumerable<IConverter> converters) => this.converters = converters;

    public IEnumerable<ConvertMenuItem> Create() //todo плохая завязка на имя
        => converters
            .Select(converter => new { converter, name = converter.GetType().Name })
            .Select(t => new ConvertMenuItem(t.converter, 
                $"{t.name.Substring(3, t.name.Length - 12)} Filter"));
}