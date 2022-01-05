using System.Drawing;

namespace Photoshop.Core.Factory;

public class RgbPixelFactory : IPixelFactory<Color>
{
    public Color CreatePixelFromColors(byte blue, byte green, byte red) => Color.FromArgb(red, green, blue);
}