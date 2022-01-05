using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbMedianConverter : RgbConverterBase<IEnumerable<Color>>
{
    public RgbMedianConverter(MedianPixelConverter pixelConverter, NeighbourhoodIterator pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}