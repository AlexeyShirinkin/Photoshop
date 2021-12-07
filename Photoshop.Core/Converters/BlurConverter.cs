using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class BlurConverter : ConverterBase<Pixel, Pixel[,]>
{
    public BlurConverter() :
        base(new BlurPixelConverter(), new WindowIterator(5))
    {
    }

    protected override Image ToImage(Pixel[,] pixels)
    {
        return new Image(pixels);
    }
}