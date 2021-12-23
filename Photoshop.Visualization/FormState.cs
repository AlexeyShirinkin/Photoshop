using Photoshop.Core.Converters;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public class FormState<TPixel> where TPixel : IPixel
{
    public bool IsImageSet => history.Count != 0;
    private Image<TPixel>? ConvertedImage { get; set; }
    private readonly IPixelFactory<TPixel> pixelFactory;
    private const double ScalingFactor = 1.05;

    private readonly Stack<(Image, Size)> history = new();
    private readonly Stack<(Image, Size)> changes = new();


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
        history.Push((newImage, newImage.Size));
        ConvertedImage = BitmapConverter.FromBitmap(new Bitmap(history.Peek().Item1), pixelFactory);
        return history.Peek().Item1;
    }

    public Image ConvertImage(IConverter<TPixel> converter)
    {
        if (!IsImageSet)
            return null;
        var convertedImage = converter.Convert(ConvertedImage
                                               ?? BitmapConverter
                                                   .FromBitmap(new Bitmap(history.Peek().Item1),
                                                               pixelFactory));
        ConvertedImage = convertedImage;
        history.Push((BitmapConverter.ToBitmap(convertedImage), history.Peek().Item2));
        changes.Clear();
        var (image, size) = history.Peek();
        return new Bitmap(image, size);
    }

    public Image Undo()
    {
        if (!IsImageSet)
            return null;
        changes.Push(history.Pop());
        ConvertedImage = null;

        if (!IsImageSet) 
            return null;
        var (image, size) = history.Peek();
        return new Bitmap(image, size);
    }

    public Image Redo()
    {
        if (changes.Count != 0)
            history.Push(changes.Pop());
        ConvertedImage = null;

        if (!IsImageSet) 
            return null;
        var (image, size) = history.Peek();
        return new Bitmap(image, size);
    }


    public Bitmap ScaleImage(int delta)
    {
        var (image, size) = history.Pop();
        history.Push((image, delta > 0
            ? new Size((int)(size.Width * ScalingFactor), (int)(size.Height * ScalingFactor))
            : new Size((int)(size.Width / ScalingFactor), (int)(size.Height / ScalingFactor))));

        return new Bitmap(history.Peek().Item1, history.Peek().Item2);
    }
}