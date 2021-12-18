using Photoshop.Core.Converters;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class FormState<TPixel>
    where TPixel : IPixel
{
    public bool IsImageSet => history.Count != 0;
    private Size Size { get; set; }
    private Image<TPixel>? ConvertedImage { get; set; }
    private readonly IPixelFactory<TPixel> pixelFactory;
    private readonly double scalingFactor = 1.05;

    private readonly Stack<Image> history = new();
    private readonly Stack<Image> changes = new();


    public FormState(IPixelFactory<TPixel> pixelFactory)
    {
        this.pixelFactory = pixelFactory;
    }

    public Image LoadImage()
    {
        var newImage = ImageLoader.Load();
        changes.Clear();
        if (newImage is null)
            throw new FileLoadException("Не получилось загрузить файл");
        Size = newImage.Size;
        history.Push(newImage);
        ConvertedImage = BitmapConverter.FromBitmap(new Bitmap(history.Peek()), pixelFactory);
        return history.Peek();
    }

    public Image ConvertImage(IConverter<TPixel> converter)
    {
        if (!IsImageSet)
            return null;
        var convertedImage = converter.Convert(ConvertedImage
                                               ?? BitmapConverter.FromBitmap(new Bitmap(history.Peek()), pixelFactory));
        ConvertedImage = convertedImage;
        history.Push(BitmapConverter.ToBitmap(convertedImage));
        changes.Clear();
        return new Bitmap(history.Peek(), Size);
    }

    public Image Undo()
    {
        if (!IsImageSet)
            return null;
        changes.Push(history.Pop());
        ConvertedImage = null;
        return IsImageSet ? new Bitmap(history.Peek(), Size) : null;
    }

    public Image Redo()
    {
        if (changes.Count != 0)
            history.Push(changes.Pop());
        ConvertedImage = null;
        return IsImageSet ? new Bitmap(history.Peek(), Size) : null;
    }


    public Bitmap ScaleImage(int delta)
    {
        Size = delta > 0
            ? new Size((int) (Size.Width * scalingFactor), (int) (Size.Height * scalingFactor))
            : new Size((int) (Size.Width / scalingFactor), (int) (Size.Height / scalingFactor));
        return new Bitmap(history.Peek(), Size);
    }
}