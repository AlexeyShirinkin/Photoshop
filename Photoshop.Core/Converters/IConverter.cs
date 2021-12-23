using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public interface IConverter<TPixel> where TPixel : IPixel
{
    Image<TPixel> Convert(Image<TPixel>? image);
}