using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public class PerPixelIterator : IPixelIterator<Pixel>
{
    public IEnumerable<PixelWrapper<Pixel>> IterateImagePixel(Image image)
    {
        for (var i = 0; i < image.Width; i++)
        {
            for (var j = 0; j < image.Height; j++)
            {
                yield return new PixelWrapper<Pixel>(i, j, image[i, j]);
            }
        }
    }
}