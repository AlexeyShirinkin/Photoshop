using Photoshop.Core.Models;

namespace Photoshop.Core.Converters;

public interface IConverter
{
    Image Convert(Image? image);
}