namespace Photoshop.Visualization;

public static class Program
{
    [STAThreadAttribute]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }    
}