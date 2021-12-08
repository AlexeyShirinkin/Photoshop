using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class SharpnessConverter : ConverterBase<Pixel, Pixel[,]>
{
    public SharpnessConverter()
        : base(new SharpnessPixelConverter(), new WindowIterator(5))
    {
    }

    protected override Image ToImage(Pixel[,] pixels)
    {
        return new Image(pixels);
    }
}