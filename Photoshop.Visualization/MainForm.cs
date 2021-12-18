using Photoshop.Core.Converters;

namespace Photoshop.Visualization;

public sealed partial class MainForm : Form //todo все на async переделать
{
    private readonly FormState formState;
    private readonly PictureBox pictureBox;
    private readonly Panel mainPanel;

    public MainForm()
    {
        formState = new FormState();
        WindowState = FormWindowState.Maximized;
        mainPanel = ViewElementsFactory.CreateLayoutPanel(PictureBoxOnMouseWheel);
        pictureBox = ViewElementsFactory.CreatePictureBox();

        Controls.Add(mainPanel);
        Controls.Add(ViewElementsFactory.CreateToolStripMenu(OnClick,
                                                             ApplicationSettings.Converters,
                                                             OnConverterClick));
        mainPanel.Controls.Add(pictureBox);
    }

    private void OnClick(object? sender, EventArgs eventArgs)
    {
        var loadedImage = ImageLoader.Load();
        if (loadedImage == null)
            return;
        formState.Image?.Dispose();
        formState.SetImage(loadedImage);
        pictureBox.Image = loadedImage;
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
        pictureBox.Update();
    }

    private void OnConverterClick(IConverter converter)
    {
        if (formState.Image == null || pictureBox == null)
            throw new Exception();
        var convertedImage = converter.Convert(formState.ConvertedImage);
        formState.SetConvertedImage(convertedImage);
        pictureBox.Image = formState.Image;
        pictureBox.Update();
    }
}