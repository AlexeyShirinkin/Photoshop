using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public abstract class ConverterBase : IConverter
{
    private readonly IPixelConverter pixelConverter;

    protected ConverterBase(IPixelConverter pixelConverter)
    {
        this.pixelConverter = pixelConverter;
    }

    public Image Convert(Image? image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));
        var newPixels = new Pixel[image.Width, image.Height];
        for (var i = 0; i < image.Width; i++)
        {
            for (var j = 0; j < image.Height; j++)
            {
                newPixels[i, j] = pixelConverter.ConvertPixel(image[i, j]);
            }
        }

        return new Image(newPixels);
    }
}