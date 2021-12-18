using Photoshop.Core.Models;

namespace Photoshop.Core.PixelConverters;

public class GrayScalePixelConverter : IPixelConverter<RgbPixel, RgbPixel>
{
    public RgbPixel ConvertPixel(RgbPixel rgbPixel)
    {
        var average = (byte)((rgbPixel.B + rgbPixel.G + rgbPixel.R) / 3);
        return new RgbPixel(average, average, average);
    }
}