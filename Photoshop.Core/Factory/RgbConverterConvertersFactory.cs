using Photoshop.Core.Converters;
using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Core.Factory;

public class RgbConverterConvertersFactory : IConvertersFactory<RgbPixel>
{
    public IConverter<RgbPixel> CreateBlurConverter()
    {
        return new RgbConverterBase<RgbPixel[,]>(new BlurPixelConverter(),
                                                 new WindowIterator<RgbPixel>(3));
    }

    public IConverter<RgbPixel> CreateEmbossingConverter()
    {
        return new RgbConverterBase<RgbPixel[,]>(new EmbossingPixelConverter(),
                                                 new WindowIterator<RgbPixel>(3));
    }

    public IConverter<RgbPixel> CreateGaussConverter()
    {
        return new RgbConverterBase<RgbPixel[,]>(new GaussPixelConverter(),
                                                 new WindowIterator<RgbPixel>(5));
    }

    public IConverter<RgbPixel> CreateGrayScaleConverter()
    {
        return new RgbConverterBase<RgbPixel>(new GrayScalePixelConverter(),
                                              new PerPixelIterator<RgbPixel>());
    }

    public IConverter<RgbPixel> CreateMedianConverter()
    {
        return new RgbConverterBase<IEnumerable<RgbPixel>>(new MedianPixelConverter(),
                                                           new NeighbourhoodIterator<RgbPixel>());
    }

    public IConverter<RgbPixel> CreateSharpnessConverter()
    {
        return new RgbConverterBase<RgbPixel[,]>(new SharpnessPixelConverter(),
                                                 new WindowIterator<RgbPixel>(3));
    }
}