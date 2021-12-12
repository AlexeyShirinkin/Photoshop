using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public class NeighbourhoodIterator<TPixel> : IPixelIterator<IEnumerable<TPixel>, TPixel>
    where TPixel : IPixel
{
    private const int Coefficient = 2;
    private readonly int coefficient;

    public NeighbourhoodIterator(int coefficient = Coefficient)
    {
        this.coefficient = coefficient;
    }

    public IEnumerable<PixelWrapper<IEnumerable<TPixel>>> IterateImagePixel(Image<TPixel> image)
    {
        for (var i = 0; i < image.Width; i++)
        {
            for (var j = 0; j < image.Height; j++)
            {
                yield return
                    new PixelWrapper<IEnumerable<TPixel>>(i, j, GetNeighborhood(i, j, image));
            }
        }
    }

    private IEnumerable<TPixel> GetNeighborhood(int i, int j, Image<TPixel> image)
    {
        var neighborhood = new List<TPixel>(coefficient * coefficient);
        for (var k = i - coefficient; k < i + coefficient + 1; k++)
        {
            for (var n = j - coefficient; n < j + coefficient + 1; n++)
            {
                if (IsImageContainsPixel(k, n, image.Width, image.Height))
                    neighborhood.Add(image[k, n]);
            }
        }

        return neighborhood;
    }

    private static bool IsImageContainsPixel(int i, int j, int width, int height)
    {
        return !(i >= width || j >= height || i < 0 || j < 0);
    }
}