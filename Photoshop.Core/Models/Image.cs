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
        var depth = System.Drawing.Image.GetPixelFormatSize(bitmap.PixelFormat);
        if (depth != 8 && depth != 24 && depth != 32)
            throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
        
        var width = bitmap.Width;
        var height = bitmap.Height;
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
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
                    var green = depth > 8 ? *tempPointer++ : blue;
                    var red = depth > 8 ? *tempPointer++ : blue;
                    if (depth > 24)
                    {
                        var alpha = *tempPointer++;
                        pixels[x, y] = Color.FromArgb(alpha, red, green, blue);
                    }
                    else pixels[x, y] = Color.FromArgb(red, green, blue);
                }

                pointer += stride;
            }
        }

        bitmap.UnlockBits(bitmapData);

        return new(pixels);
    }

    public Bitmap ToBitmap(PixelFormat pixelFormat)
    {
        var depth = System.Drawing.Image.GetPixelFormatSize(pixelFormat);
        if (depth != 8 && depth != 24 && depth != 32)
            throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");

        var bitmap = new Bitmap(Width, Height);
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, pixelFormat);

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
                    if (depth > 8)
                    {
                        *tempPointer++ = rgb.G;
                        *tempPointer++ = rgb.R;
                    }
                    if (depth > 24)
                    {
                        *tempPointer++ = rgb.A;
                    }
                }

                pointer += stride;
            }
        }

        bitmap.UnlockBits(bitmapData);

        return bitmap;
    }
}