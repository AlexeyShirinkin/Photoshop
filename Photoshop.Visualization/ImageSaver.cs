namespace Photoshop.Visualization;

public static class ImageSaver
{
    public static void Save(Image image)
    {
        var saveFileDialog = new SaveFileDialog();
        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            return;

        image.Save(saveFileDialog.FileName, image.RawFormat);
        MessageBox.Show("Файл сохранен");
    }
}