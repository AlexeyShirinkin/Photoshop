using Photoshop.Core.Models;

namespace Photoshop.Core.PixelConverters;

public class BlurPixelConverter : IPixelConverter<Pixel[,], Pixel>
{
    private static readonly double[,] Matrix = new double[5, 5]
                                               {
                                                   {
                                                       0.000789, 0.006581, 0.013347, 0.006581,
                                                       0.000789
                                                   },
                                                   {
                                                       0.006581, 0.054901, 0.111345, 0.054901,
                                                       0.006581
                                                   },
                                                   {
                                                       0.013347, 0.111345, 0.22581, 0111345,
                                                       0.013347
                                                   },
                                                   {
                                                       0.006581, 0.054901, 0.111345, 0.054901,
                                                       0.006581
                                                   },
                                                   {
                                                       0.000789, 0.006581, 0.013347, 0.006581,
                                                       0.000789
                                                   }
                                               };

    public Pixel ConvertPixel(Pixel[,] pixel)
    {
        var resultR = 0;
        var resultB = 0;
        var resultG = 0;
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                resultR += (int)(pixel[i, j].R * Matrix[i, j]);
                resultB += (int)(pixel[i, j].B * Matrix[i, j]);
                resultG += (int)(pixel[i, j].G * Matrix[i, j]);
            }
        }

        return new Pixel((byte)resultR, (byte)resultG, (byte)resultB);
    }
}