using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbBlurConverter : RgbConverterBase<RgbPixel[,]>
{
    public RgbBlurConverter(BlurPixelConverter pixelConverter, WindowIterator<RgbPixel> pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}