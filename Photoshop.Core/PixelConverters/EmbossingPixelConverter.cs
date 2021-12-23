namespace Photoshop.Core.PixelConverters;

public class EmbossingPixelConverter : PixelMatrixConverterBase
{
    public EmbossingPixelConverter() :
        base(new[,]
        {
            {-1, -1, 0},
            {-1, 0, 1},
            {0, 1, 1}
        }, 1)
    {
    }
}