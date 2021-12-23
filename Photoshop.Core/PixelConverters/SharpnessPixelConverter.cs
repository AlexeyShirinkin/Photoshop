namespace Photoshop.Core.PixelConverters;

public class SharpnessPixelConverter : PixelMatrixConverterBase
{
    public SharpnessPixelConverter()
        : base(new[,]
        {
            {-1, -1, -1},
            {-1, 9, -1},
            {-1, -1, -1}
        }, 1)
    {
    }
}