namespace Photoshop.Core.Models;

public class Image
{
    public int Width { get; }
    public int Height { get; }
    private Pixel[,] pixels; //TODO: зависимость от пикселей нехорошо,можно переделать на какую-нибудь абстракццию

    public Image(Pixel[,] pixels)
    {
        this.pixels = pixels;
        Width = pixels.GetLength(0);
        Height = pixels.GetLength(1);
    }
}