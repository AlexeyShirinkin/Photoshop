using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public class WindowIterator<TPixel> : IPixelIterator<TPixel[,], TPixel>
    where TPixel : IPixel
{
    private readonly int width;
    private readonly int height;

    public WindowIterator(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public WindowIterator(int size)
    {
        height = size;
        width = size;
    }

    public IEnumerable<PixelWrapper<TPixel[,]>> IterateImagePixel(Image<TPixel> image)
    {
        for (var i = 0; i < image.Width; i++)
        {
            for (var j = 0; j < image.Height; j++)
            {
                yield return
                    new PixelWrapper<TPixel[,]>(i, j, GetNeighborhood(i, j, image));
            }
        }
    }

    private TPixel[,] GetNeighborhood(int i, int j, Image<TPixel> image)
    {
        var neighborhood = new TPixel[width, height];
        var rowCount = 0;
        for (var k = i - width / 2; k < i + width / 2 + 1; k++)
        {
            var columnCount = 0;
            for (var n = j - height / 2; n < j + height / 2 + 1; n++)
            {
                if (IsImageContainsPixel(k, n, image.Width, image.Height))
                    neighborhood[rowCount, columnCount] =
                        (TPixel)image[k, n]; //todo not a good idea
                else
                    neighborhood[rowCount, columnCount] = default(TPixel);
                columnCount++;
            }

            rowCount++;
        }

        return neighborhood;
    }

    private static bool IsImageContainsPixel(int i, int j, int width, int height)
    {
        return !(i >= width || j >= height || i < 0 || j < 0);
    }
}