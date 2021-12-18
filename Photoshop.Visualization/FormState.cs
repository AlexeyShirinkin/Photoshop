using Photoshop.Core.Converters;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class FormState<TPixel>
    where TPixel : IPixel
{
    public bool IsImageSet => Image != null;
    private Image? Image { get; set; }
    private Size Size { get; set; }
    private Image<TPixel>? ConvertedImage { get; set; }
    private readonly IPixelFactory<TPixel> pixelFactory;
    private readonly double scalingFactor = 1.05;

    public FormState(IPixelFactory<TPixel> pixelFactory)
    {
        this.pixelFactory = pixelFactory;
    }

    public Image LoadImage()
    {
        var newImage = ImageLoader.Load();
        Image?.Dispose();
        if (newImage is null)
            throw new FileLoadException("Не получилось загрузить файл");
        Size = newImage.Size;
        Image = newImage;
        ConvertedImage = BitmapConverter.FromBitmap(new Bitmap(newImage), pixelFactory);
        return newImage;
    }

    public Image ConvertImage(IConverter<TPixel> converter)
    {
        if (!IsImageSet)
            return null;
        var convertedImage = converter.Convert(ConvertedImage);
        ConvertedImage = convertedImage;
        Image = BitmapConverter.ToBitmap(convertedImage);
        return new Bitmap(Image, Size);
    }


    public Bitmap ScaleImage(int delta)
    {
        Size = delta > 0
            ? new Size((int) (Size.Width * scalingFactor), (int) (Size.Height * scalingFactor))
            : new Size((int) (Size.Width / scalingFactor), (int) (Size.Height / scalingFactor));
        return new Bitmap(Image, Size);
    }
}