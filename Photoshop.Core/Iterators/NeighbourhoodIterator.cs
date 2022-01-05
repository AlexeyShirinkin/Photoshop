using System.Drawing;
using Image = Photoshop.Core.Models.Image;

namespace Photoshop.Core.Iterators;

public class NeighbourhoodIterator : IPixelIterator<IEnumerable<Color>>
{
    private const int Coefficient = 2;
    private readonly int coefficient;

    public NeighbourhoodIterator(int coefficient = Coefficient)
    {
        this.coefficient = coefficient;
    }

    public IEnumerable<PixelWrapper<IEnumerable<Color>>> IterateImagePixel(Image image)
    {
        for (var i = 0; i < image.Width; ++i)
            for (var j = 0; j < image.Height; ++j)
                yield return new PixelWrapper<IEnumerable<Color>>(i, j, GetNeighborhood(i, j, image));
    }

    private IEnumerable<Color> GetNeighborhood(int i, int j, Image image)
    {
        for (var k = i - coefficient; k < i + coefficient + 1; ++k)
            for (var n = j - coefficient; n < j + coefficient + 1; ++n)
                if (IsImageContainsPixel(k, n, image.Width, image.Height))
                    yield return image[k, n];
    }

    private static bool IsImageContainsPixel(int i, int j, int width, int height) => 
        !(i >= width || j >= height || i < 0 || j < 0);
}