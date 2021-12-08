namespace Photoshop.Core.PixelConverters;

public class EmbossingPixelConverter : MatrixConverterBase
{
    public EmbossingPixelConverter()
        : base(new[,]
               {
                   { -1, -1, 0 },
                   { -1, 0, 1 },
                   { 0, 1, 1 }
               }, 1)
    {
    }
}