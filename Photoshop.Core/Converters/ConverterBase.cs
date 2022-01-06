using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public abstract class ConverterBase<TResult, TInput> : IConverter
{
    private readonly IPixelConverter<TInput, TResult> pixelConverter;
    private readonly IPixelIterator<TInput> pixelIterator;

    protected ConverterBase(IPixelConverter<TInput, TResult> pixelConverter,
        IPixelIterator<TInput> pixelIterator)
    {
        this.pixelConverter = pixelConverter;
        this.pixelIterator = pixelIterator;
    }

    public Image Convert(Image? image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));
        var newPixels = new TResult[image.Width, image.Height];
        pixelIterator.IterateImagePixel(image)
            .AsParallel()
            .ForAll(pw => newPixels[pw.X, pw.Y] = pixelConverter.ConvertPixel(pw.Item));

        return ToImage(newPixels);
    }

    protected abstract Image ToImage(TResult[,] pixels);
}