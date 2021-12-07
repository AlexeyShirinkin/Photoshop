using Photoshop.Core.Models;

namespace Photoshop.Core.PixelConverters;

public class GrayScalePixelConverter : IPixelConverter<Pixel, Pixel>
{
    public Pixel ConvertPixel(Pixel pixel)
    {
        var average = (byte)((pixel.B + pixel.G + pixel.R) / 3);
        return new Pixel(average, average, average);
    }
}