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
        Func<object?, EventArgs, Task> onLoad,
        Func<object?, EventArgs, Task> onSave,
        IEnumerable<ConvertMenuItem> convertMenuItems,
        IEnumerable<RotateMenuItem> rotateMenuItems,
        Action<IConverter> onClick,
        Action<RotateFlipType> onRotate,
        EventHandler onUndo,
        EventHandler onRedo)
    {
        var menu = new MenuStrip();
        menu.Dock = DockStyle.Top;
        menu.Stretch = true;
        menu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        menu.BackColor = Color.WhiteSmoke;

        return menu
            .With(CreateFileItem("File")
                .With(CreateToolStripMenuItem("Load", onLoad))
                .With(CreateToolStripMenuItem("Save", onSave)))
            .With(GetTransformMenu(convertMenuItems, onClick))
            .With(GetRotateMenu(rotateMenuItems, onRotate))
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
    
    private static ToolStripMenuItem GetRotateMenu(IEnumerable<RotateMenuItem> convertMenuItems, Action<RotateFlipType> onRotate)
    {
        var menuItem = CreateFileItem("Rotate");
        return convertMenuItems.Aggregate(menuItem,
            (current, convertMenuItem) => current.With(
                CreateToolStripMenuItem(convertMenuItem.Name, () => onRotate(convertMenuItem.Action))));
    }

    private static ToolStripMenuItem CreateFileItem(string text) => new(text);

    private static ToolStripMenuItem CreateToolStripMenuItem(
        string text,
        Action<IConverter> onClick,
        IConverter converter)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += (_, _) => onClick(converter);
        return toolStripMenuItem;
    }
    
    private static ToolStripMenuItem CreateToolStripMenuItem(string text, Action onRotate)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += (_, _) => onRotate();
        return toolStripMenuItem;
    }

    private static ToolStripMenuItem CreateToolStripMenuItem(string text, EventHandler onCLick)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += onCLick;
        return toolStripMenuItem;
    }
    
    private static ToolStripMenuItem CreateToolStripMenuItem(string text, Func<object?, EventArgs, Task> onClick)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += (sender, args) => onClick(sender, args);
        return toolStripMenuItem;
    }
}