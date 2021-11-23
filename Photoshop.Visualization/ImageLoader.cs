namespace Photoshop.Visualization;

public static class ImageLoader
{
    public static Image? Load()
    {
        var openDialog = new OpenFileDialog();
        openDialog.Filter =
            "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

        if (openDialog.ShowDialog() != DialogResult.OK)
        {
            MessageBox.Show("Unable to open provider", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            return null;
        }

        if (!TryGetImage(openDialog.FileName, out var image))
            MessageBox.Show("Unable to open file", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

        return image;
    }

    private static bool TryGetImage(string fileName, out Image? image)
    {
        try
        {
            image = new Bitmap(fileName);
            return true;
        }
        catch
        {
            image = null;
            return false;
        }
    }
}