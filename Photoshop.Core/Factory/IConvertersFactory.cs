using Photoshop.Core.Converters;
using Photoshop.Core.Models;

namespace Photoshop.Core.Factory;

public interface IConvertersFactory
{
    IConverter CreateBlurConverter();
    IConverter CreateEmbossingConverter();
    IConverter CreateGaussConverter();
    IConverter CreateGrayScaleConverter();
    IConverter CreateMedianConverter();
    IConverter CreateSharpnessConverter();
}