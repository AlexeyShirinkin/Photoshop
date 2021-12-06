using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public interface IPixelConverter
{
    Pixel ConvertPixel(Pixel pixel);
}