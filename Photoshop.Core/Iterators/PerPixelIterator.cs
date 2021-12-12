using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public class PerPixelIterator<TPixel> : IPixelIterator<TPixel, TPixel>
    where TPixel : IPixel
{
    public IEnumerable<PixelWrapper<TPixel>> IterateImagePixel(Image<TPixel> image)
    {
        for (var i = 0; i < image.Width; i++)
        {
            for (var j = 0; j < image.Height; j++)
            {
                yield return new PixelWrapper<TPixel>(i, j, image[i, j]); //todo not a good idea
            }
        }
    }
}