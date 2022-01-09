namespace Photoshop.Visualization;

public static class ImageSaver
{
    public static async Task Save(Image image)
    {
        var saveFileDialog = new SaveFileDialog();
        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            return;

        var result = await Task.Run(() => Save(image, saveFileDialog.FileName));
        MessageBox.Show(result ? "Файл сохранен" : "Файл не сохранен");
    }

    private static bool Save(Image image, string fileName)
    {
        try
        {
            image.Save(fileName);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}