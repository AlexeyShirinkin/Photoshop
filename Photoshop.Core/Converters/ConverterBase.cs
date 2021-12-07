using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public abstract class ConverterBase<TPixel, TReturn> : IConverter
{
    private readonly IPixelConverter<TReturn, TPixel> pixelConverter;
    private readonly IPixelIterator<TReturn> pixelIterator;

    protected ConverterBase(IPixelConverter<TReturn, TPixel> pixelConverter,
                            IPixelIterator<TReturn> pixelIterator)
    {
        this.pixelConverter = pixelConverter;
        this.pixelIterator = pixelIterator;
    }

    public Image Convert(Image? image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));
        var newPixels = new TPixel[image.Width, image.Height];
        foreach (var pixelWrapper in pixelIterator.IterateImagePixel(image))
        {
            var newPixel = pixelConverter.ConvertPixel(pixelWrapper.Item);
            newPixels[pixelWrapper.X, pixelWrapper.Y] = newPixel;
        }

        return ToImage(newPixels);
    }

    protected abstract Image ToImage(TPixel[,] pixels);
}