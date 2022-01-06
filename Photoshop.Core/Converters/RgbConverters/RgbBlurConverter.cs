using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbBlurConverter : RgbConverterBase<Color[,]>
{
    public RgbBlurConverter(BlurPixelConverter pixelConverter, WindowIterator pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}