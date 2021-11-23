using System.Drawing;

namespace Photoshop.Core.Models;

public class Pixel
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public Pixel(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public Color GetColorFromRgb()
    {
        return Color.FromArgb(R, G, B);
    }
}