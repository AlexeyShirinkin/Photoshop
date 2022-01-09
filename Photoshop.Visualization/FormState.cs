using Photoshop.Core.Converters;
using Image = System.Drawing.Image;

namespace Photoshop.Visualization;

public class FormState
{
    public bool IsImageSet => history.Count != 0;
    private const double ScalingFactor = 1.05;

    private readonly Stack<(Bitmap, Size)> history = new();
    private readonly Stack<(Bitmap, Size)> changes = new();

    public async Task<Bitmap> LoadImage()
    {
        var newImage = await ImageLoader.Load();
        changes.Clear();
        if (newImage is null)
            throw new FileLoadException("Не получилось загрузить файл");
        history.Push((newImage, newImage.Size));
        return history.Peek().Item1;
    }
    
    public async Task SaveImage()
    {
        if (!IsImageSet)
            return;

        await ImageSaver.Save(history.Peek().Item1);
    }

    public Image ConvertImage(IConverter converter)
    {
        if (!IsImageSet)
            return null;
        var (bitmap, size) = history.Peek();
        var convertedImage = converter.Convert(Core.Models.Image.FromBitmap(bitmap));
        var image = convertedImage.ToBitmap(bitmap.PixelFormat);
        
        history.Push((image, size));
        changes.Clear();
        return new Bitmap(image, size);
    }

    public Image Undo()
    {
        if (!IsImageSet)
            return null;
        changes.Push(history.Pop());

        if (!IsImageSet)
            return null;
        var (bitmap, size) = history.Peek();
        return new Bitmap(bitmap, size);
    }

    public Image Redo()
    {
        if (changes.Count != 0)
            history.Push(changes.Pop());

        if (!IsImageSet)
            return null;
        var (bitmap, size) = history.Peek();
        return new Bitmap(bitmap, size);
    }

    public Image Rotate(RotateFlipType flipType)
    {
        if (!IsImageSet)
            return null;
        
        var (bitmap, size) = history.Peek();

        var newBitmap = new Bitmap(bitmap, size);
        newBitmap.RotateFlip(flipType);

        history.Push((newBitmap, newBitmap.Size));
        changes.Clear();
        return newBitmap;
    }

    public Bitmap ScaleImage(int delta)
    {
        var (image, size) = history.Pop();
        var newSize = delta > 0
            ? new Size((int) (size.Width * ScalingFactor), (int) (size.Height * ScalingFactor))
            : new Size((int) (size.Width / ScalingFactor), (int) (size.Height / ScalingFactor));

        if (!(newSize.Width is >= 144 and <= 2560 && newSize.Height is >= 144 and <= 2560))
            newSize = size;

        history.Push((image, newSize));
        return new Bitmap(image, newSize);
    }
}