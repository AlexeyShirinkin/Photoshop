using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbMedianConverter : RgbConverterBase<IEnumerable<RgbPixel>>
{
    public RgbMedianConverter(MedianPixelConverter pixelConverter,
                              NeighbourhoodIterator<RgbPixel> pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}