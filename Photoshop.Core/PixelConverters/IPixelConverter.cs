namespace Photoshop.Core.PixelConverters;

public interface IPixelConverter<in TInput, out TResult>
{
    TResult ConvertPixel(TInput pixel);
}