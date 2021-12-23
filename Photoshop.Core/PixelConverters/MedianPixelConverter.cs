using Photoshop.Core.Models;

namespace Photoshop.Core.PixelConverters;

public class MedianPixelConverter : IPixelConverter<IEnumerable<RgbPixel>, RgbPixel>
{
    public RgbPixel ConvertPixel(IEnumerable<RgbPixel> pixel)
    {
        var pixels = pixel.OrderBy(pixel1 => pixel1.Brightness).ToList();
        return pixels.Count % 2 != 0 
            ? pixels[pixels.Count / 2 + 1] 
            : pixels[pixels.Count / 2];
    }
}