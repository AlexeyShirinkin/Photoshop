namespace Photoshop.Core.Models;

public record PixelRecord
{
    public int R;
    public int G;
    public int B;

    public int X;
    public int Y;

    public PixelRecord Aggregate(PixelRecord other, int scale)
    {
        B = B + other.B * scale;
        G = G + other.G * scale;
        R = R + other.R * scale;
        return this;
    }
}