using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public interface IPixelIterator<T>
{
    IEnumerable<PixelWrapper<T>> IterateImagePixel(Image image);
}