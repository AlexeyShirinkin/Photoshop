namespace Photoshop.Visualization;

public sealed partial class MainForm : Form
{
    public MainForm()
    {
        var panel = CreateLayoutPanel();
        
        var loadButton = CreateLoadButton();
        panel.Controls.Add(loadButton);

        var pictureBox = CreatePictureBox();
        panel.Controls.Add(pictureBox);
        
        Controls.Add(panel);
        AutoSize = true;
        
        loadButton.Click += (_, _) =>
        {
            var image = ImageLoader.Load();
            if (image is null)
                return;
            
            pictureBox.Image = image;
        };
    }
    
    private static Button CreateLoadButton() =>
        new()
        {
            Text = "Load image",
            AutoSize = true
        };
    
    private static PictureBox CreatePictureBox() =>
        new()
        {
            AutoSize = true
        };
    
    private static FlowLayoutPanel CreateLayoutPanel() =>
        new()
        {
            AutoSize = true,
            FlowDirection = FlowDirection.TopDown
        };
}