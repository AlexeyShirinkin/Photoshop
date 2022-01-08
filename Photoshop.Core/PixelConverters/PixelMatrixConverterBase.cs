using System.Drawing;
using Photoshop.Core.Models;
using Photoshop.Core.Utilities;

namespace Photoshop.Core.PixelConverters;

public class PixelMatrixConverterBase : MatrixConverterBase<PixelRecord, Color>
{
    public PixelMatrixConverterBase(int[,] matrix, int coefficient) : base(matrix, coefficient)
    {
    }

    protected override PixelRecord Convert(Color pixel, int i, int j)
    {
        return new PixelRecord
        {
            R = pixel.R,
            G = pixel.G,
            B = pixel.B,
            Location = new Point(i, j)
        };
    }

    protected override PixelRecord Aggregate(PixelRecord previous, PixelRecord current)
        => previous.Aggregate(current, Matrix[current.Location.X, current.Location.Y]);

    protected override PixelRecord Default => new();

    protected override Color ConvertToPixel(PixelRecord result) =>
        Color.FromArgb(
            (result.R / Coefficient).ToByte(),
            (result.G / Coefficient).ToByte(),
            (result.B / Coefficient).ToByte());
}