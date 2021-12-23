namespace Photoshop.Visualization.Utilities;

public static class ToolStripMenuExtensions
{
    public static MenuStrip With(this MenuStrip menu, ToolStripMenuItem item)
    {
        if (menu is null)
            throw new ArgumentNullException(nameof(menu));
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        menu.Items.Add(item);
        return menu;
    }

    public static ToolStripMenuItem With(this ToolStripMenuItem item, ToolStripMenuItem child)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        if (child is null)
            throw new ArgumentNullException(nameof(child));

        item.DropDownItems.Add(child);
        return item;
    }
}