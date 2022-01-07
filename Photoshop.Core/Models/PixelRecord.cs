using System.Drawing;

namespace Photoshop.Core.Models;

public record struct PixelRecord
{
    public int R;
    public int G;
    public int B;
    public Point Location;

    public PixelRecord Aggregate(PixelRecord other, int scale)
    {
        B += other.B * scale;
        G += other.G * scale;
        R += other.R * scale;
        return this;
    }
}