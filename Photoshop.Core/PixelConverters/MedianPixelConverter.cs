using System.Drawing;

namespace Photoshop.Core.PixelConverters;

public class MedianPixelConverter : IPixelConverter<IEnumerable<Color>, Color>
{
    public Color ConvertPixel(IEnumerable<Color> pixel)
    {
        var pixels = pixel.OrderBy(pixel1 => (pixel1.B + pixel1.G + pixel1.R) / 3).ToArray();
        return pixels.Length % 2 != 0 
            ? pixels[pixels.Length / 2 + 1] 
            : pixels[pixels.Length / 2];
    }
}