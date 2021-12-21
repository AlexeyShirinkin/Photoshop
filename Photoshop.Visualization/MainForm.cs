using Photoshop.Core.Converters;
using Photoshop.Core.Models;

namespace Photoshop.Visualization;

public sealed partial class MainForm : Form //todo все на async переделать
{
    private readonly FormState<RgbPixel> formState;
    private readonly PictureBox pictureBox;
    private readonly IConvertMenuItemFactory<RgbPixel> convertMenuItemFactory;

    public MainForm(FormState<RgbPixel> formState,
                    IConvertMenuItemFactory<RgbPixel>
                        convertMenuItemFactory) //todo плохая завязка на RgbPixel
    {
        this.formState = formState;
        this.convertMenuItemFactory = convertMenuItemFactory;
        WindowState = FormWindowState.Maximized;
        var mainPanel = ViewElementsFactory.CreateLayoutPanel(PictureBoxOnMouseWheel);
        pictureBox = ViewElementsFactory.CreatePictureBox();
        Controls.Add(mainPanel);
        Controls.Add(ViewElementsFactory.CreateToolStripMenu(
                                                             OnLoadClick,
                                                             convertMenuItemFactory.Create(),
                                                             OnConverterClick,
                                                             OnUndoClick,
                                                             OnRedoClick));
        mainPanel.Controls.Add(pictureBox);
    }

    private void OnLoadClick(object? sender, EventArgs eventArgs)
    {
        pictureBox.Image = formState.LoadImage();
    }

    private void OnUndoClick(object? sender, EventArgs eventArgs)
    {
        pictureBox.Image = formState.Undo();
    }

    private void OnRedoClick(object? sender, EventArgs eventArgs)
    {
        pictureBox.Image = formState.Redo();
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