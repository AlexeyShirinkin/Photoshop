using Photoshop.Core.Converters;

namespace Photoshop.Visualization;

public class FormState
{
    public Image? Image { get; private set; }
    public Core.Models.Image? ConvertedImage { get; private set; }

    public void SetImage(Image? newImage, Core.Models.Image? newConvertedImage = null)
    {
        if (newImage is null)
            return;
        Image = newImage;
        ConvertedImage = newConvertedImage ?? BitmapConverter.FromBitmap(new Bitmap(newImage));
    }
}