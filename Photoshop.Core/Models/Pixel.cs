namespace Photoshop.Core.Models;

public class Pixel
{
    public double R { get; }
    public double G { get; }
    public double B { get; }

    public Pixel(double r, double g, double b)
    {
        R = r;
        G = g;
        B = b;
    }
}