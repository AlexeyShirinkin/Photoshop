namespace Photoshop.Core.Converters;

public class GrayscaleConverter : ConverterBase
{
    public GrayscaleConverter() : base(new GrayScalePixelConverter())
    {
    }
}