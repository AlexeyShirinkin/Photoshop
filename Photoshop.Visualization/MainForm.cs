using Photoshop.Core.Converters;
using Photoshop.Core.Factory;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public sealed partial class MainForm : Form //todo все на async переделать
{
    private readonly FormState<RgbPixel> formState;
    private readonly PictureBox pictureBox;
    private readonly Panel mainPanel;

    public MainForm()
    {
        formState = new FormState<RgbPixel>(new RgbPixelFactory());
        WindowState = FormWindowState.Maximized;
        mainPanel = ViewElementsFactory.CreateLayoutPanel(PictureBoxOnMouseWheel);
        pictureBox = ViewElementsFactory.CreatePictureBox();

        Controls.Add(mainPanel);
        Controls.Add(ViewElementsFactory.CreateToolStripMenu(OnLoadClick,
                                                             ApplicationSettings
                                                                 .GetConverters(new
                                                                     RgbConverterConvertersFactory()),
                                                             OnConverterClick));
        mainPanel.Controls.Add(pictureBox);
    }

    private void OnLoadClick(object? sender, EventArgs eventArgs)
    {
        pictureBox.Image = formState.LoadImage();
    }

    private void PictureBoxOnMouseWheel(object? sender, MouseEventArgs e)
    {
        if (ModifierKeys != Keys.Control || !formState.IsImageSet)
            return;
        
        pictureBox.Image = formState.ScaleImage(e.Delta); 
        pictureBox.Update();
    }

    private void OnConverterClick(IConverter<RgbPixel> converter)
    {
        pictureBox.Image = formState.ConvertImage(converter); 
        pictureBox.Update();
    }
}