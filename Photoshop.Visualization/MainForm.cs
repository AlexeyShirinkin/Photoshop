using Photoshop.Core.Converters;

namespace Photoshop.Visualization;

public sealed partial class MainForm : Form
{
    private readonly FormState formState;
    private readonly PictureBox pictureBox;
    private readonly Panel mainPanel;

    public MainForm()
    {
        formState = new FormState();
        WindowState = FormWindowState.Maximized;
        mainPanel = CreateLayoutPanel();
        pictureBox = CreatePictureBox();

        Controls.Add(CreateLoadButton());
        Controls.Add(CreateRotateButton());
        Controls.Add(mainPanel);
        mainPanel.Controls.Add(pictureBox);
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
        pictureBox.Image = new Bitmap(formState.Image, newSize);
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Update();
    }

    private Button CreateLoadButton()
    {
        var button = new Button();
        button.Text = "Load image";
        button.AutoSize = true;
        button.Click += (_, _) =>
                        {
                            var loadedImage = ImageLoader.Load();
                            if (loadedImage == null)
                                return;

                            formState.Image?.Dispose();
                            formState.SetImage(loadedImage);
                            pictureBox.Image = loadedImage;
                            pictureBox.Dock = DockStyle.Fill;
                        };
        return button;
    }

    private static PictureBox CreatePictureBox()
    {
        return new PictureBox
               {
                   AutoSize = true,
               };
    }

    private Panel CreateLayoutPanel()
    {
        var panel = new Panel();
        panel.Location = new Point(0, 50);
        panel.AutoScroll = true;
        panel.AutoSize = true;
        panel.MouseWheel += PictureBoxOnMouseWheel;
        return panel;
    }

    private Button CreateRotateButton()
    {
        var rotateButton = new Button();
        rotateButton.Text = "Rotate";
        rotateButton.Location = new Point(50, 0);
        rotateButton.Click += (sender, args) =>
                              {
                                  if (formState.Image is null || pictureBox is null)
                                      return;
                                  var newImage =
                                      new RotateConverter().Convert(formState.ConvertedImage);
                                  var bitmap = BitmapConverter.ToBitmap(newImage);
                                  pictureBox.Image = bitmap;
                                  formState.SetImage(bitmap, newImage);
                                  pictureBox.Update();
                              };
        return rotateButton;
    }
}