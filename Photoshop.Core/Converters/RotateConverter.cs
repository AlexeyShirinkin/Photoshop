using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public class RotateConverter : IConverter
{
    public Image Convert(Image? image)
    {
        var pixels = new Pixel[image.Height, image.Width];
        for (var i = 0; i < image.Height; i++)
        {
            for (var j = 0; j < image.Width; j++)
            {
                pixels[i, j] = image[j, i];
            }
        }

        return new Image(pixels);
    }
}