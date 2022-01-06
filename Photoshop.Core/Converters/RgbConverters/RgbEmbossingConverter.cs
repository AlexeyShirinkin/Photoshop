using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbEmbossingConverter : RgbConverterBase<Color[,]>
{
    public RgbEmbossingConverter(EmbossingPixelConverter pixelConverter, WindowIterator pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}