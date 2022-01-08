using Photoshop.Core.Converters;

namespace Photoshop.Visualization;

public sealed partial class MainForm : Form //todo все на async переделать
{
    private readonly FormState formState;
    private readonly PictureBox pictureBox;
    private readonly Panel mainPanel;

    public MainForm(FormState formState, IConvertMenuItemFactory convertMenuItemFactory)
    {
        this.formState = formState;
        WindowState = FormWindowState.Maximized;
        mainPanel = ViewElementsFactory.CreateLayoutPanel(PictureBoxOnMouseWheel);
        pictureBox = ViewElementsFactory.CreatePictureBox();
        Controls.Add(mainPanel);

        Controls.Add(ViewElementsFactory.CreateToolStripMenu(OnLoadClick,
                                                             OnSaveClick,
                                                             convertMenuItemFactory.Create(),
                                                             RotateMenuItemFactory.Create(),
                                                             OnConverterClick,
                                                             OnRotateClick,
                                                             OnUndoClick,
                                                             OnRedoClick));
        mainPanel.Controls.Add(pictureBox);
    }

    private void OnLoadClick(object? sender, EventArgs eventArgs) => pictureBox.Image = formState.LoadImage();

    private void OnSaveClick(object? sender, EventArgs eventArgs) => formState.SaveImage();

    private void OnUndoClick(object? sender, EventArgs eventArgs) => pictureBox.Image = formState.Undo();

    private void OnRedoClick(object? sender, EventArgs eventArgs) => pictureBox.Image = formState.Redo();

    private void OnRotateClick(RotateFlipType flipType) => pictureBox.Image = formState.Rotate(flipType);

    private void OnConverterClick(IConverter converter) => pictureBox.Image = formState.ConvertImage(converter);

    private void PictureBoxOnMouseWheel(object? sender, MouseEventArgs e)
    {
        if (ModifierKeys != Keys.Control || !formState.IsImageSet)
            return;

        pictureBox.Image = formState.ScaleImage(e.Delta);

        if (e.Delta <= 0)
            return;

        mainPanel.HorizontalScroll.Value = (int) (e.X / (double) mainPanel.Width * mainPanel.HorizontalScroll.Maximum);
        mainPanel.VerticalScroll.Value = (int) (e.Y / (double) mainPanel.Height * mainPanel.VerticalScroll.Maximum);
    }
}