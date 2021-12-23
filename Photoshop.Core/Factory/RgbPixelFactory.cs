using Photoshop.Core.Models;

namespace Photoshop.Core.Factory;

public class RgbPixelFactory : IPixelFactory<RgbPixel>
{
    public RgbPixel CreatePixelFromColors(byte blue, byte green, byte red) => new(red, green, blue);
}