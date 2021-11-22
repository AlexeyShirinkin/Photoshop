namespace Photoshop.Visualization;

public sealed partial class MainForm : Form
{
    private Image? image;
    private readonly PictureBox pictureBox;
    
    public MainForm()
    {
        WindowState = FormWindowState.Maximized;
        
        var loadButton = CreateLoadButton();
        Controls.Add(loadButton);
        
        var panel = CreateLayoutPanel();
        Controls.Add(panel);

        pictureBox = CreatePictureBox();
        panel.Controls.Add(pictureBox);
        
        panel.MouseWheel += PictureBoxOnMouseWheel;
        
        loadButton.Click += (_, _) =>
        {
            var loadedImage = ImageLoader.Load();
            if (loadedImage == null)
                return;

            image?.Dispose();
            image = loadedImage;
            pictureBox.Image = loadedImage;
        };
    }

    private void PictureBoxOnMouseWheel(object? sender, MouseEventArgs e)
    {
        if (ModifierKeys != Keys.Control)
            return;
        
        const double factor = 1.05;
        var size = pictureBox.Image.Size;
        var newSize = e.Delta > 0
            ? new Size((int)(size.Width * factor), (int)(size.Height * factor))
            : new Size((int)(size.Width / factor), (int)(size.Height / factor));
        pictureBox.Image = new Bitmap(image!, newSize);
        pictureBox.Update();
    }
    
    private static Button CreateLoadButton() =>
        new()
        {
            Text = "Load image",
            AutoSize = true
        };
    
    private static PictureBox CreatePictureBox() =>
        new()
        {
            AutoSize = true,
        };
    
    private static Panel CreateLayoutPanel() =>
        new()
        {
            Location = new Point(0, 50),
            Size = new Size(900, 900),
            AutoScroll = true,
        };
}