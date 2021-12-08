namespace Photoshop.Core.PixelConverters;

public class SharpnessPixelConverter : MatrixConverterBase
{
    public SharpnessPixelConverter()
        : base(new[,]
               {
                   { -1, -1, -1 },
                   { -1, 9, -1 },
                   { -1, -1, -1 }
               }, 1)
    {
    }
}