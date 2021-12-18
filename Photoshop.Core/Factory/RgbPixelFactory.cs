using System.Drawing;
using Photoshop.Core.Models;

namespace Photoshop.Core.Factory;

public class RgbPixelFactory : IPixelFactory<RgbPixel>
{
    public RgbPixel CreatePixelFromColor(Color color)
    {
        return new RgbPixel(color.R, color.G, color.B);
    }
}