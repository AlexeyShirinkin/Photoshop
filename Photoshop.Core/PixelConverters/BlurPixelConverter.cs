namespace Photoshop.Core.PixelConverters;

public class BlurPixelConverter : PixelMatrixConverterBase
{
    public BlurPixelConverter() :
        base(new[,]
        {
            {-1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        }, 1)
    {
    }
}