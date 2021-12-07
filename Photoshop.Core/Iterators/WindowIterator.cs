using Photoshop.Core.Models;

namespace Photoshop.Core.Iterators;

public class WindowIterator : IPixelIterator<Pixel[,]>
{
    private readonly int windowSize;

    public WindowIterator(int windowSize)
    {
        this.windowSize = windowSize / 2;
    }

    public IEnumerable<PixelWrapper<Pixel[,]>> IterateImagePixel(Image image)
    {
        for (var i = 0; i < image.Width; i++)
        {
            for (var j = 0; j < image.Height; j++)
            {
                yield return
                    new PixelWrapper<Pixel[,]>(i, j, GetNeighborhood(i, j, image));
            }
        }
    }

    private Pixel[,] GetNeighborhood(int i, int j, Image image)
    {
        var neighborhood = new Pixel[windowSize * 2 + 1, windowSize * 2 + 1];
        var rowCount = 0;
        for (var k = i - windowSize; k < i + windowSize + 1; k++)
        {
            var columnCount = 0;
            for (var n = j - windowSize; n < j + windowSize + 1; n++)
            {
                if (IsImageContainsPixel(k, n, image.Width, image.Height))
                    neighborhood[rowCount, columnCount] = image[k, n];
                else
                    neighborhood[rowCount, columnCount] = new Pixel(0, 0, 0);
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