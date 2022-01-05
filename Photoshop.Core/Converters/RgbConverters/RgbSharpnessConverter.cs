using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters.RgbConverters;

public class RgbSharpnessConverter : RgbConverterBase<Color[,]>
{
    public RgbSharpnessConverter(SharpnessPixelConverter pixelConverter, WindowIterator pixelIterator) :
        base(pixelConverter, pixelIterator)
    {
    }
}