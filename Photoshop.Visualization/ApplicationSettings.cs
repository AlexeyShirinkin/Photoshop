using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public static class ApplicationSettings //todo: rename
{
    public static IReadOnlyCollection<ConvertMenuItem<RgbPixel>> GetConverters(
        IConvertersFactory<RgbPixel> convertersFactory)
    {
        return new[]
               {
                   new ConvertMenuItem<RgbPixel>(convertersFactory.CreateGrayScaleConverter(),
                                                 "Gray Filter"),
                   new ConvertMenuItem<RgbPixel>(convertersFactory.CreateBlurConverter(),
                                                 "Blur Filter"),
                   new ConvertMenuItem<RgbPixel>(convertersFactory.CreateMedianConverter(),
                                                 "Clear Noise Filter"),
                   new ConvertMenuItem<RgbPixel>(convertersFactory.CreateSharpnessConverter(),
                                                 "Sharpness Filter"),
                   new ConvertMenuItem<RgbPixel>(convertersFactory.CreateEmbossingConverter(),
                                                 "Embossing Filter"),
                   new ConvertMenuItem<RgbPixel>(convertersFactory.CreateGaussConverter(),
                                                 "Gauss Filter")
               };
    }
}