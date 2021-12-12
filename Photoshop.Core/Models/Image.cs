namespace Photoshop.Core.Models;

public class Image<TPixel>
    where TPixel : IPixel
{
    public int Width { get; }
    public int Height { get; }

    private readonly TPixel[,]
        pixels; //TODO: зависимость от пикселей нехорошо,можно переделать на какую-нибудь абстракццию

    public Image(TPixel[,] pixels)
    {
        this.pixels = pixels;
        Width = pixels.GetLength(0);
        Height = pixels.GetLength(1);
    }

    public TPixel this[int i, int j] => pixels[i, j];
}