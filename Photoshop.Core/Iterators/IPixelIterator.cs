using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public interface IPixelIterator<TIterate, TPixel> where TPixel : IPixel
{
    IEnumerable<PixelWrapper<TIterate>> IterateImagePixel(Image<TPixel> image);
}