using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class EmbossingConverter : ConverterBase<Pixel, Pixel[,]>
{
    public EmbossingConverter()
        : base(new EmbossingPixelConverter(), new WindowIterator(5))
    {
    }

    protected override Image ToImage(Pixel[,] pixels)
    {
        return new Image(pixels);
    }
}