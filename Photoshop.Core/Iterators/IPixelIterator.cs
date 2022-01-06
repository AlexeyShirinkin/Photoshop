using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public interface IPixelIterator<TIterate>
{
    IEnumerable<PixelWrapper<TIterate>> IterateImagePixel(Image image);
}