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
        Controls.Add(ViewElementsFactory.CreateToolStripMenu(OnClick, OnRotateClick,
                                                             OnToGrayClick));
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
        pictureBox.Dock = DockStyle.Fill;
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

    private void OnToGrayClick(object? sender, EventArgs eventArgs)
    {
        if (formState.Image == null || pictureBox == null)
            throw new Exception();
        var converter = new GrayscaleConverter();
        var convertedImage = converter.Convert(formState.ConvertedImage);
        formState.SetConvertedImage(convertedImage);
        pictureBox.Image = formState.Image;
        pictureBox.Update();
    }

    private void OnRotateClick(object? sender, EventArgs args)
    {
        if (formState.Image is null || pictureBox is null)
            return;
        // var rotationAngle = 90;
        // var bmp = new Bitmap(formState.Image.Width, formState.Image.Height);
        //
        // var gfx = Graphics.FromImage(bmp);
        // gfx.Clear(Color.White);
        // gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
        // gfx.RotateTransform(rotationAngle);
        // gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
        // gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
        // gfx.DrawImage(formState.Image, new Point(0, 0));
        // gfx.Dispose();
    }
}