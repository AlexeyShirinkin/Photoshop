using System.Drawing;
using Photoshop.Core.Models;
using Image = Photoshop.Core.Models.Image;

namespace Photoshop.Core.Converters;

public static class BitmapConverter
{
    public static Image? FromBitmap(Bitmap bitmap)
    {
        var pixels = new Pixel[bitmap.Width, bitmap.Height];
        for (var x = 0; x < bitmap.Width; x++)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                var pixel = bitmap.GetPixel(x, y);
                pixels[x, y] = new Pixel(pixel.R, pixel.G, pixel.B);
            }
        }

        return new Image(pixels);
    }

    public static Bitmap ToBitmap(Image image)
    {
        var bitmap = new Bitmap(image.Width, image.Height);
        for (var x = 0; x < image.Width; x++)
        {
            for (var y = 0; y < image.Height; y++)
            {
                var pixel = image[x, y];
                bitmap.SetPixel(x, y, pixel.GetColorFromRgb());
            }
        }

        return bitmap;
    }
}