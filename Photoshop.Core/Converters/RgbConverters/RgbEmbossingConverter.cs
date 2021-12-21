using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbEmbossingConverter : RgbConverterBase<RgbPixel[,]>
{
    public RgbEmbossingConverter(EmbossingPixelConverter pixelConverter,
                                 WindowIterator<RgbPixel> pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}