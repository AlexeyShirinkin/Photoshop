using System.Drawing;

namespace Photoshop.Core.PixelConverters;

public class MedianPixelConverter : IPixelConverter<IEnumerable<Color>, Color>
{
    public Color ConvertPixel(IEnumerable<Color> pixel)
    {
        var pixels = pixel.OrderBy(pixel1 => pixel1.GetBrightness()).ToList();
        return pixels.Count % 2 != 0 
            ? pixels[pixels.Count / 2 + 1] 
            : pixels[pixels.Count / 2];
    }
}