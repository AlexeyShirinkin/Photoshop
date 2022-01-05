using Photoshop.Core.Converters;
using Photoshop.Visualization.Utilities;

namespace Photoshop.Visualization;

public static class ViewElementsFactory
{
    public static PictureBox CreatePictureBox() =>
        new()
        {
            AutoSize = true
        };

    public static Panel CreateLayoutPanel(MouseEventHandler mouseEventHandler)
    {
        var panel = new Panel();
        panel.Location = new Point(0, 50);
        panel.AutoScroll = true;
        panel.Size = new Size(900, 900);
        panel.MouseWheel += mouseEventHandler;
        return panel;
    }

    public static MenuStrip CreateToolStripMenu(
        EventHandler onLoad,
        IEnumerable<ConvertMenuItem> convertMenuItems,
        Action<IConverter> onClick,
        EventHandler onUndo,
        EventHandler onRedo)
    {
        var menu = new MenuStrip();
        menu.Dock = DockStyle.Top;
        menu.Stretch = true;
        menu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        menu.BackColor = Color.WhiteSmoke;

        return menu
            .With(CreateFileItem("File").With(CreateToolStripMenuItem("Load", onLoad)))
            .With(GetTransformMenu(convertMenuItems, onClick))
            .With(CreateToolStripMenuItem("Undo", onUndo))
            .With(CreateToolStripMenuItem("Redo", onRedo));
    }

    private static ToolStripMenuItem GetTransformMenu(
        IEnumerable<ConvertMenuItem> convertMenuItems,
        Action<IConverter> onClick)
    {
        var menuItem = CreateFileItem("Transform");
        return convertMenuItems.Aggregate(menuItem,
            (current, convertMenuItem) => current.With(
                CreateToolStripMenuItem(convertMenuItem.MenuName, onClick, convertMenuItem.Converter)));
    }

    private static ToolStripMenuItem CreateFileItem(string text) => new ToolStripMenuItem(text);

    private static ToolStripMenuItem CreateToolStripMenuItem(
        string text,
        Action<IConverter> onClick,
        IConverter converter)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += (_, _) => onClick(converter);
        return toolStripMenuItem;
    }

    private static ToolStripMenuItem CreateToolStripMenuItem(string text, EventHandler onCLick)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += onCLick;
        return toolStripMenuItem;
    }
}