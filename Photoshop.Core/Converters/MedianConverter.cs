using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class MedianConverter : ConverterBase<Pixel, IEnumerable<Pixel>>
{
    public MedianConverter()
        : base(new MedianPixelConverter(),
               new NeighbourhoodIterator())
    {
    }

    protected override Image ToImage(Pixel[,] pixels)
    {
        return new Image(pixels);
    }
}