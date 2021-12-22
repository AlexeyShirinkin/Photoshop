using Photoshop.Core.Models;
using Photoshop.Core.Utilities;

namespace Photoshop.Core.PixelConverters;

public abstract class MatrixConverterBase<T, TPixel> : IPixelConverter<TPixel[,], TPixel>
    where TPixel : IPixel
{
    protected readonly int[,] Matrix;
    protected readonly int Coefficient;
    protected readonly int Width;
    protected readonly int Height;

    protected MatrixConverterBase(int[,] matrix, int coefficient)
    {
        Matrix = matrix;
        Coefficient = coefficient;
        Width = matrix.GetLength(0);
        Height = matrix.GetLength(1);
    }

    public TPixel ConvertPixel(TPixel[,] pixel)
    {
        if (pixel.GetLength(0) != Width || pixel.GetLength(1) != Height)
            throw new Exception("Не совпадают размерности матрицы свертки ");
        var aggregated = pixel.Enumerate(Convert).Aggregate(Default, Aggregate);
        return ConvertToPixel(aggregated);
    }

    protected abstract T Convert(TPixel pixel, int i, int j);
    protected abstract T Aggregate(T previous, T current);
    protected abstract T Default { get; }
    protected abstract TPixel ConvertToPixel(T result);
}