using Photoshop.Visualization.Utilities;

namespace Photoshop.Visualization;

public static class ViewElementsFactory
{
    public static PictureBox CreatePictureBox()
    {
        return new PictureBox
               {
                   AutoSize = true,
               };
    }

    public static Panel CreateLayoutPanel(MouseEventHandler mouseEventHandler)
    {
        var panel = new Panel();
        panel.Location = new Point(0, 50);
        panel.AutoScroll = true;
        panel.AutoSize = true;
        panel.MouseWheel += mouseEventHandler;
        return panel;
    }

    public static MenuStrip CreateToolStripMenu(EventHandler onClick, EventHandler onRotateClick)
    {
        var menu = new MenuStrip();
        menu.Dock = DockStyle.Top;
        menu.Stretch = true;
        menu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        menu.BackColor = Color.WhiteSmoke;
        return menu
               .With(CreateFileItem("File")
                         .With(CreateToolStripMenuItem("Load", onClick)))
               .With(CreateFileItem("Transform")
                         .With(CreateToolStripMenuItem("Rotate", onRotateClick)));
    }

    private static ToolStripMenuItem CreateFileItem(string text)
    {
        return new ToolStripMenuItem(text);
    }

    private static ToolStripMenuItem CreateToolStripMenuItem(string text, EventHandler onClick)
    {
        var toolStripMenuItem = new ToolStripMenuItem(text);
        toolStripMenuItem.Click += onClick;
        return toolStripMenuItem;
    }


    public static Button CreateRotateButton(EventHandler onClick)
    {
        var rotateButton = new Button();
        rotateButton.Text = "Rotate";
        rotateButton.Location = new Point(50, 0);
        rotateButton.Click += onClick;
        return rotateButton;
    }
}