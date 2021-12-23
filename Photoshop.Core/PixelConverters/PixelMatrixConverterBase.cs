using Photoshop.Core.Models;
using Photoshop.Core.Utilities;

namespace Photoshop.Core.PixelConverters;

public class PixelMatrixConverterBase : MatrixConverterBase<PixelRecord, RgbPixel>
{
    public PixelMatrixConverterBase(int[,] matrix, int coefficient) : base(matrix, coefficient)
    {
    }

    protected override PixelRecord Convert(RgbPixel? pixel, int i, int j)
    {
        return new PixelRecord
        {
            R = pixel?.R ?? 0,
            G = pixel?.G ?? 0,
            B = pixel?.B ?? 0,
            X = i,
            Y = j
        };
    }

    protected override PixelRecord Aggregate(PixelRecord previous, PixelRecord current)
        => previous.Aggregate(current, Matrix[current.X, current.Y]);

    protected override PixelRecord Default => new();

    protected override RgbPixel ConvertToPixel(PixelRecord result) =>
        new((result.R / Coefficient).ToByte(),
            (result.G / Coefficient).ToByte(),
            (result.B / Coefficient).ToByte());
}