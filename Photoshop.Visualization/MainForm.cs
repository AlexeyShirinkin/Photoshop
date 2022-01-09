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
        Size = new Size(920, 1000);
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        
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

    private async Task OnLoadClick(object? sender, EventArgs eventArgs) => pictureBox.Image = await formState.LoadImage();

    private async Task OnSaveClick(object? sender, EventArgs eventArgs) => await formState.SaveImage();

    private async void OnUndoClick(object? sender, EventArgs eventArgs) => pictureBox.Image = await Task.Run(() => formState.Undo());

    private async void OnRedoClick(object? sender, EventArgs eventArgs) => pictureBox.Image = await Task.Run(() => formState.Redo());

    private async void OnRotateClick(RotateFlipType flipType) => pictureBox.Image = await Task.Run(() => formState.Rotate(flipType));

    private async void OnConverterClick(IConverter converter) => pictureBox.Image = await Task.Run(() => formState.ConvertImage(converter));

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