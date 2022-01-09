namespace Photoshop.Visualization;

public static class ImageLoader
{
    public static async Task<Bitmap?> Load()
    {
        var openDialog = new OpenFileDialog
        {
            Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
        };

        if (openDialog.ShowDialog() != DialogResult.OK)
        {
            MessageBox.Show("Unable to open provider", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var image = await Task.Run(() => GetImage(openDialog.FileName));
        if (image is null)
            MessageBox.Show("Unable to open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        return image;
    }

    private static Bitmap? GetImage(string fileName)
    {
        try
        {
            return new Bitmap(fileName);
        }
        catch
        {
            return null;
        }
    }
}