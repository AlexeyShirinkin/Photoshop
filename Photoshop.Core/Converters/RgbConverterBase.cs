using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class RgbConverterBase<TIterate> : ConverterBase<RgbPixel, TIterate, RgbPixel>
{
    public RgbConverterBase(IPixelConverter<TIterate, RgbPixel> pixelConverter,
                            IPixelIterator<TIterate, RgbPixel> pixelIterator)
        : base(pixelConverter, pixelIterator)
    {
    }

    protected override Image<RgbPixel> ToImage(RgbPixel[,] pixels)
    {
        return new Image<RgbPixel>(pixels);
    }
}