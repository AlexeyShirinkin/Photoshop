namespace Photoshop.Core.Factory;

public interface IPixelFactory<out TPixel>
{
    TPixel CreatePixelFromColors(byte blue, byte green, byte red);
}