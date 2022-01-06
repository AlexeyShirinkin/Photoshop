using System.Drawing;
using Image = Photoshop.Core.Models.Image;

namespace Photoshop.Core.Iterators;

public class WindowIterator : IPixelIterator<Color[,]>
{
    private readonly int height;
    private readonly int width;

    public WindowIterator(int size)
    {
        height = size;
        width = size;
    }

    public IEnumerable<PixelWrapper<Color[,]>> IterateImagePixel(Image image)
    {
        for (var i = 0; i < image.Width; ++i)
            for (var j = 0; j < image.Height; ++j)
                yield return
                    new PixelWrapper<Color[,]>(i, j, GetNeighborhood(i, j, image));
    }

    private Color[,] GetNeighborhood(int i, int j, Image image)
    {
        var neighborhood = new Color[width, height];
        var rowCount = 0;
        for (var k = i - width / 2; k < i + width / 2 + 1; ++k)
        {
            var columnCount = 0;
            for (var n = j - height / 2; n < j + height / 2 + 1; ++n)
            {
                if (IsImageContainsPixel(k, n, image.Width, image.Height))
                    neighborhood[rowCount, columnCount] = image[k, n]; //todo not a good idea
                else neighborhood[rowCount, columnCount] = default;
                ++columnCount;
            }

            ++rowCount;
        }

        return neighborhood;
    }

    private static bool IsImageContainsPixel(int i, int j, int width, int height) => 
        !(i >= width || j >= height || i < 0 || j < 0);
}