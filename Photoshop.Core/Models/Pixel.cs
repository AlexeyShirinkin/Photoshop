using System.Drawing;

namespace Photoshop.Core.Models;

public class Pixel
{
    public static Pixel Empty => new Pixel(0, 0, 0);
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    public double Brightness { get; }

    public Pixel(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
        Brightness = 0.3 * R + 0.59 * G + 0.11 * B;
    }

    public Pixel(int argb)
    {
        var color = Color.FromArgb(argb);
        R = color.R;
        G = color.G;
        B = color.B;
        Brightness = 0.3 * R + 0.59 * G + 0.11 * B;
    }

    public Color GetColorFromRgb()
    {
        return Color.FromArgb(R, G, B);
    }
}