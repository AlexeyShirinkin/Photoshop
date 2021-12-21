using Ninject;
using Photoshop.Visualization.Configuration;

namespace Photoshop.Visualization;

public static class Program
{
    [STAThreadAttribute]
    private static void Main()
    {
        var kernelConfiguration = new StandardKernel();
        AppConfiguration.Configure(kernelConfiguration);
        ApplicationConfiguration.Initialize();
        var mainForm = kernelConfiguration.Get<MainForm>();
        Application.Run(mainForm);
    }
}