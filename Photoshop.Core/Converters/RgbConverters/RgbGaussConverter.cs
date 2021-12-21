using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbGaussConverter : RgbConverterBase<RgbPixel[,]>
{
    public RgbGaussConverter(GaussPixelConverter pixelConverter,
                             WindowIterator<RgbPixel> pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}