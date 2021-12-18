﻿using Photoshop.Core.Models;

namespace Photoshop.Core.PixelConverters;

public class MedianPixelConverter : IPixelConverter<IEnumerable<RgbPixel>, RgbPixel>
{
    public RgbPixel ConvertPixel(IEnumerable<RgbPixel> pixel)
    {
        var pixels = pixel.ToList();
        pixels.Sort((pixel1, pixel2) => pixel1.Brightness.CompareTo(pixel2.Brightness));
        if (pixels.Count % 2 == 0)
            return pixels[pixels.Count / 2 - 1];
        return pixels[pixels.Count / 2];
    }
}