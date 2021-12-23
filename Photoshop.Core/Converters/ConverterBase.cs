using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public abstract class ConverterBase<TResult, TInput, TPixel> : IConverter<TPixel>
    where TPixel : IPixel
{
    private readonly IPixelConverter<TInput, TResult> pixelConverter;
    private readonly IPixelIterator<TInput, TPixel> pixelIterator;

    protected ConverterBase(IPixelConverter<TInput, TResult> pixelConverter,
        IPixelIterator<TInput, TPixel> pixelIterator)
    {
        this.pixelConverter = pixelConverter;
        this.pixelIterator = pixelIterator;
    }

    public Image<TPixel> Convert(Image<TPixel>? image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));
        var newPixels = new TResult[image.Width, image.Height];
        foreach (var pixelWrapper in pixelIterator.IterateImagePixel(image))
            newPixels[pixelWrapper.X, pixelWrapper.Y] = pixelConverter.ConvertPixel(pixelWrapper.Item);

        return ToImage(newPixels);
    }

    protected abstract Image<TPixel> ToImage(TResult[,] pixels);
}