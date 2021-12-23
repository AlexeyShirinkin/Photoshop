using System.Drawing;
using System.Drawing.Imaging;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public static class BitmapConverter
{
    public static Image<TPixel> FromBitmap<TPixel>(Bitmap bitmap, IPixelFactory<TPixel> pixelFactory)
        where TPixel : IPixel
    {
        var width = bitmap.Width;
        var height = bitmap.Height;
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);
        var stride = bitmapData.Stride;
        var pixels = new TPixel[width, height];

        unsafe
        {
            var pointer = (byte*) bitmapData.Scan0;

            for (var y = 0; y < height; ++y)
            {
                var tempPointer = pointer;
                for (var x = 0; x < width; ++x)
                {
                    pixels[x, y] = pixelFactory.CreatePixelFromColors(*tempPointer++, *tempPointer++, *tempPointer++);
                    ++tempPointer;
                }

                pointer += stride;
            }
        }

        bitmap.UnlockBits(bitmapData);

        return new Image<TPixel>(pixels);
    }

    public static Bitmap ToBitmap<TPixel>(Image<TPixel> image) where TPixel : IPixel
    {
        var width = image.Width;
        var height = image.Height;

        var bitmap = new Bitmap(width, height);
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
            PixelFormat.Format24bppRgb);

        unsafe
        {
            var pointer = (byte*) bitmapData.Scan0;
            var stride = bitmapData.Stride;
            for (var y = 0; y < height; ++y)
            {
                var tempPointer = pointer;
                for (var x = 0; x < width; ++x)
                {
                    var rgb = image[x, y].GetColor();
                    *tempPointer++ = rgb.B;
                    *tempPointer++ = rgb.G;
                    *tempPointer++ = rgb.R;
                }

                pointer += stride;
            }
        }

        bitmap.UnlockBits(bitmapData);

        return bitmap;
    }
}