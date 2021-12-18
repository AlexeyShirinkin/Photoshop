namespace Photoshop.Core.PixelConverters;

public class GaussPixelConverter : PixelMatrixConverterBase
{
    public GaussPixelConverter()
        : base(new int[,]
               {
                   { 1, 4, 7, 4, 1 },
                   { 4, 16, 26, 16, 4 },
                   { 7, 26, 41, 26, 7 },
                   { 4, 16, 26, 16, 4 },
                   { 1, 4, 7, 4, 1 }
               }, 273)
    {
    }
}