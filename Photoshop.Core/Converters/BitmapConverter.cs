using System.Drawing;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public static class BitmapConverter
{
    public static Image<TPixel>? FromBitmap<TPixel>(Bitmap bitmap,
                                                    IPixelFactory<TPixel> pixelFactory)
        where TPixel : IPixel
    {
        var pixels = new TPixel[bitmap.Width, bitmap.Height];
        for (var x = 0; x < bitmap.Width; x++)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                var color = bitmap.GetPixel(x, y);
                pixels[x, y] = pixelFactory.CreatePixelFromColor(color);
            }
        }

        return new Image<TPixel>(pixels);
    }

    public static Bitmap ToBitmap<TPixel>(Image<TPixel> image)
        where TPixel : IPixel
    {
        var bitmap = new Bitmap(image.Width, image.Height);
        for (var x = 0; x < image.Width; x++)
        {
            for (var y = 0; y < image.Height; y++)
            {
                var pixel = image[x, y];
                bitmap.SetPixel(x, y, pixel.GetColor());
            }
        }

        return bitmap;
    }
}