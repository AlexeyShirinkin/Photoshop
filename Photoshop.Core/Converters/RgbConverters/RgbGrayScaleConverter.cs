using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbGrayScaleConverter : RgbConverterBase<Color>
{
    public RgbGrayScaleConverter(GrayScalePixelConverter pixelConverter,
                                 PerPixelIterator pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}