using System.Drawing;

namespace Photoshop.Core.PixelConverters;

public class GrayScalePixelConverter : IPixelConverter<Color, Color>
{
    public Color ConvertPixel(Color rgbPixel)
    {
        var average = (byte)((rgbPixel.B + rgbPixel.G + rgbPixel.R) / 3);
        return Color.FromArgb(average, average, average);
    }
}