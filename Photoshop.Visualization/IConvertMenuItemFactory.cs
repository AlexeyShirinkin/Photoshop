namespace Photoshop.Visualization;

public interface IConvertMenuItemFactory
{
    IEnumerable<ConvertMenuItem> Create();
}