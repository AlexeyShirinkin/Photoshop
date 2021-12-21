using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbGrayScaleConverter : RgbConverterBase<RgbPixel>
{
    public RgbGrayScaleConverter(GrayScalePixelConverter pixelConverter,
                                 PerPixelIterator<RgbPixel> pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}