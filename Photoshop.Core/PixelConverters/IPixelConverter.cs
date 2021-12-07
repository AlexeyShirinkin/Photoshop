namespace Photoshop.Core.PixelConverters;

public interface IPixelConverter<TPixel, TReturn>
{
    TReturn ConvertPixel(TPixel pixel);
}