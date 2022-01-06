using System.Drawing;
using System.Drawing.Imaging;

namespace Photoshop.Core.Models;

public class Image
{
    public int Width { get; }
    public int Height { get; }

    private readonly Color[,] pixels;

    public Color this[int i, int j] => pixels[i, j];

    private Image(Color[,] pixels)
    {
        this.pixels = pixels;
        Width = pixels.GetLength(0);
        Height = pixels.GetLength(1);
    }

    public static Image FromPixels(Color[,] pixels) => new Image(pixels);

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

    public Bitmap ToBitmap()
    {
        var bitmap = new Bitmap(Width, Height);
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly,
            PixelFormat.Format24bppRgb);

        unsafe
        {
            var pointer = (byte*) bitmapData.Scan0;
            var stride = bitmapData.Stride;
            for (var y = 0; y < Height; ++y)
            {
                var tempPointer = pointer;
                for (var x = 0; x < Width; ++x)
                {
                    var rgb = pixels[x, y];
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