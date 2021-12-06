using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public class GrayScalePixelConverter : IPixelConverter
{
    public Pixel ConvertPixel(Pixel pixel)
    {
        var average = (pixel.B + pixel.G + pixel.R) / 3;
        return new Pixel(average, average, average);
    }
}