namespace Photoshop.Visualization;

public static class ImageLoader
{
    public static Image? Load()
    {
        var openDialog = new OpenFileDialog();
        openDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

        if (openDialog.ShowDialog() != DialogResult.OK) 
            return null;

        Image image;
        try
        {
            image = new Bitmap(openDialog.FileName);
        }
        catch
        {
            MessageBox.Show("Unable to open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return image;
    }
}