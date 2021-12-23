using System.Drawing;

namespace Photoshop.Core.Models;

public class RgbPixel : IPixel
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    public double Brightness { get; }

    public RgbPixel(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
        Brightness = 0.3 * R + 0.59 * G + 0.11 * B;
    }

    public Color GetColor() => Color.FromArgb(R, G, B);
}