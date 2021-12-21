using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public interface IConvertMenuItemFactory<TPixel>
    where TPixel : IPixel
{
    IEnumerable<ConvertMenuItem<TPixel>> Create();
}