using System.Drawing;
using Image = Photoshop.Core.Models.Image;

namespace Photoshop.Core.Iterators;

public class PerPixelIterator : IPixelIterator<Color>
{
    public IEnumerable<PixelWrapper<Color>> IterateImagePixel(Image image)
    {
        for (var i = 0; i < image.Width; ++i)
            for (var j = 0; j < image.Height; ++j)
                yield return new PixelWrapper<Color>(i, j, image[i, j]); //todo not a good idea
    }
}