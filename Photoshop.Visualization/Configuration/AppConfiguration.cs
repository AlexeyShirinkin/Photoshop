using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Syntax;
using Photoshop.Core.Converters;
using Photoshop.Core.Converters.RgbConverters;
using Photoshop.Core.Iterators;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Visualization.Configuration;

public static class AppConfiguration
{
    public static void Configure(StandardKernel kernel)
    {
        ConfigureIterators(kernel);
        ConfigurePixelIterators(kernel);
        ConfigureRgbConverters(kernel);

        kernel.Bind<FormState>().ToSelf().InSingletonScope();
        kernel.Bind<IConvertMenuItemFactory>().To<ConvertMenuItemFactory>().InSingletonScope();
    }

    private static void ConfigureIterators(IBindingRoot bindingRoot)
    {
        bindingRoot.Bind<NeighbourhoodIterator>()
                   .ToSelf()
                   .InSingletonScope();
        bindingRoot.Bind<PerPixelIterator>()
                   .ToSelf()
                   .InSingletonScope();
        bindingRoot.Bind<WindowIterator>()
                   .ToMethod(_ => new WindowIterator(3))
                   .InSingletonScope();
        bindingRoot.Bind<WindowIterator>()
                   .ToMethod(_ => new WindowIterator(5))
                   .WhenInjectedInto<RgbGaussConverter>()
                   .InSingletonScope();
    }

    private static void ConfigurePixelIterators(IBindingRoot bindingRoot)
    {
        bindingRoot.Bind(syntax => syntax.FromThisAssembly()
                                         .SelectAllClasses()
                                         .InheritedFrom<IPixelConverter<Color, Color>>()
                                         .BindAllInterfaces()
                                         .Configure(x => x.InSingletonScope()));
        bindingRoot.Bind(syntax => syntax.FromThisAssembly()
                                         .SelectAllClasses()
                                         .InheritedFrom<IPixelConverter<Color[,], Color>>()
                                         .BindAllInterfaces()
                                         .Configure(x => x.InSingletonScope()));
    }

    private static void ConfigureRgbConverters(IBindingRoot bindingRoot)
    {
        bindingRoot.Bind<IConverter>().To<RgbBlurConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter>().To<RgbEmbossingConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter>().To<RgbGaussConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter>().To<RgbGrayScaleConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter>().To<RgbMedianConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter>().To<RgbSharpnessConverter>().InSingletonScope();
    }
}