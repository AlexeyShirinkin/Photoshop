using Photoshop.Core.Models;

namespace Photoshop.Core.PixelConverters;

public class MedianPixelConverter : IPixelConverter<IEnumerable<Pixel>, Pixel>
{
    public Pixel ConvertPixel(IEnumerable<Pixel> pixel)
    {
        var pixels = pixel.OrderBy(x => x.Brightness).ToList(); //todo bad idea
        if (pixels.Count % 2 == 0)
            return pixels[pixels.Count / 2 - 1];
        return pixels[pixels.Count / 2];
    }
}