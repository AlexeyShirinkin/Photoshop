﻿using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Converters;

public class GrayscaleConverter : ConverterBase<Pixel, Pixel>
{
    public GrayscaleConverter() : base(new GrayScalePixelConverter(),
                                       new PerPixelIterator())
    {
    }

    protected override Image ToImage(Pixel[,] pixels)
    {
        return new Image(pixels);
    }
}