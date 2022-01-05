using System.Drawing;
using System.Drawing.Imaging;
using Image = Photoshop.Core.Models.Image;

namespace Photoshop.Core.Converters;

public static class BitmapConverter
{
    public static Image FromBitmap(Bitmap bitmap)
    {
        var width = bitmap.Width;
        var height = bitmap.Height;
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);
        var stride = bitmapData.Stride;
        var pixels = new Color[width, height];

        unsafe
        {
            var pointer = (byte*) bitmapData.Scan0;

            for (var y = 0; y < height; ++y)
            {
                var tempPointer = pointer;
                for (var x = 0; x < width; ++x)
                {
                    var blue = *tempPointer++;
                    var green = *tempPointer++;
                    var red = *tempPointer++;

                    pixels[x, y] = Color.FromArgb(red, green, blue);
                    ++tempPointer;
                }

                pointer += stride;
            }
        }

        bitmap.UnlockBits(bitmapData);

        return new(pixels);
    }

    public static Bitmap ToBitmap(Image image)
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
                    var rgb = image[x, y];
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