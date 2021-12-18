using Photoshop.Core.Converters;
using Photoshop.Core.Models;

namespace Photoshop.Core.Factory;

public interface IConvertersFactory<TPixel>
    where TPixel : IPixel
{
    IConverter<TPixel> CreateBlurConverter();
    IConverter<TPixel> CreateEmbossingConverter();
    IConverter<TPixel> CreateGaussConverter();
    IConverter<TPixel> CreateGrayScaleConverter();
    IConverter<TPixel> CreateMedianConverter();
    IConverter<TPixel> CreateSharpnessConverter();
}