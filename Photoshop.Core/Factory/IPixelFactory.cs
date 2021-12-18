using System.Drawing;

namespace Photoshop.Core.Factory;

public interface IPixelFactory<out TPixel>
{
    TPixel CreatePixelFromColor(Color color);
}