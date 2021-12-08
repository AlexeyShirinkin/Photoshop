using Photoshop.Core.Models;
using Photoshop.Core.Utilities;

namespace Photoshop.Core.PixelConverters;

public abstract class MatrixConverterBase : IPixelConverter<Pixel[,], Pixel>
{
    private readonly int[,] matrix;
    private readonly int coefficient;
    private readonly int width;
    private readonly int height;

    protected MatrixConverterBase(int[,] matrix, int coefficient)
    {
        this.matrix = matrix;
        this.coefficient = coefficient;
        width = matrix.GetLength(0);
        height = matrix.GetLength(1);
    }

    public Pixel ConvertPixel(Pixel[,] pixel)
    {
        var resultR = 0;
        var resultG = 0;
        var resultB = 0;
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                resultR += pixel[i, j].R * matrix[i, j];
                resultG += pixel[i, j].G * matrix[i, j];
                resultB += pixel[i, j].B * matrix[i, j];
            }
        }

        return new Pixel((resultR / coefficient).ToByte(),
                         (resultG / coefficient).ToByte(),
                         (resultB / coefficient).ToByte());
    }
}