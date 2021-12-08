using Photoshop.Core.Converters;

namespace Photoshop.Visualization;

public static class ApplicationSettings //todo: rename
{
    public static IReadOnlyCollection<ConvertMenuItem> Converters => new[]
        {
            new ConvertMenuItem(new GrayscaleConverter(), "Gray Filter"),
            new ConvertMenuItem(new BlurConverter(), "Blur Filter"),
            new ConvertMenuItem(new MedianConverter(), "Clear Noise Filter"),
            new ConvertMenuItem(new SharpnessConverter(), "Sharpness Filter"),
            new ConvertMenuItem(new EmbossingConverter(), "Embossing Filter"),
            new ConvertMenuItem(new GaussConverter(), "Gauss Filter")
        };
}