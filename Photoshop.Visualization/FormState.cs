using Photoshop.Core.Converters;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class FormState<TPixel>
    where TPixel : IPixel
{
    public Image? Image { get; private set; }
    public Image<TPixel>? ConvertedImage { get; private set; }
    private readonly IPixelFactory<TPixel> pixelFactory;

    public FormState(IPixelFactory<TPixel> pixelFactory)
    {
        this.pixelFactory = pixelFactory;
    }


    public void SetImage(Image? newImage, Image<TPixel>? newConvertedImage = null)
    {
        if (newImage is null)
            return;
        Image = newImage;
        ConvertedImage = newConvertedImage ??
                         BitmapConverter.FromBitmap<TPixel>(new Bitmap(newImage), pixelFactory);
    }

    public void SetConvertedImage(Image<TPixel> image)
    {
        ConvertedImage = image;
        Image = BitmapConverter.ToBitmap<TPixel>(image);
    }
}