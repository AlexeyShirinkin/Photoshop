using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class GaussConverter : ConverterBase<Pixel, Pixel[,]>
{
    public GaussConverter()
        : base(new GaussPixelConverter(),
               new WindowIterator(5))
    {
    }

    protected override Image ToImage(Pixel[,] pixels)
    {
        return new Image(pixels);
    }
}