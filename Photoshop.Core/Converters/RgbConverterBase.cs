using System.Drawing;
using Photoshop.Core.Iterators;
using Photoshop.Core.PixelConverters;
using Image = Photoshop.Core.Models.Image;

namespace Photoshop.Core.Converters;

public abstract class RgbConverterBase<TIterate> : ConverterBase<Color, TIterate>
{
    protected RgbConverterBase(IPixelConverter<TIterate, Color> pixelConverter, IPixelIterator<TIterate> pixelIterator)
        : base(pixelConverter, pixelIterator)
    {
    }

    protected override Image ToImage(Color[,] pixels) => new(pixels);
}