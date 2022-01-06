using System.Drawing;

namespace Photoshop.Core.Models;

public class Image
{
    public int Width { get; }
    public int Height { get; }

    private readonly Color[,] pixels;

    public Image(Color[,] pixels)
    {
        this.pixels = pixels;
        Width = pixels.GetLength(0);
        Height = pixels.GetLength(1);
    }

    public Color this[int i, int j] => pixels[i, j];
}