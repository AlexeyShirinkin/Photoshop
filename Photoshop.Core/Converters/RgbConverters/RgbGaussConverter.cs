using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbGaussConverter : RgbConverterBase<Color[,]>
{
    public RgbGaussConverter(GaussPixelConverter pixelConverter, WindowIterator pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}