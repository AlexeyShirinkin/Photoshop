using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Syntax;
using Photoshop.Core.Converters;
using Photoshop.Core.Converters.RgbConverters;
using Photoshop.Core.Factory;
using Photoshop.Core.Iterators;
using Photoshop.Core.Models;
using Photoshop.Core.PixelConverters;

namespace Photoshop.Visualization.Configuration;

public static class AppConfiguration
{
    public static void Configure(StandardKernel kernel)
    {
        ConfigureIterators<RgbPixel>(kernel);
        ConfigurePixelIterators<RgbPixel>(kernel);
        ConfigureRgbConverters(kernel);

        kernel.Bind<IPixelFactory<RgbPixel>>().To<RgbPixelFactory>().InSingletonScope();
        kernel.Bind<FormState<RgbPixel>>().ToSelf().InSingletonScope();
        kernel.Bind<IConvertMenuItemFactory<RgbPixel>>().To<ConvertMenuItemFactory<RgbPixel>>()
              .InSingletonScope();
    }

    private static void ConfigureIterators<TPixel>(IBindingRoot bindingRoot)
        where TPixel : IPixel
    {
        bindingRoot.Bind<NeighbourhoodIterator<TPixel>>()
                   .ToSelf()
                   .InSingletonScope();
        bindingRoot.Bind<PerPixelIterator<TPixel>>()
                   .ToSelf()
                   .InSingletonScope();
        bindingRoot.Bind<WindowIterator<TPixel>>()
                   .ToMethod(context => new WindowIterator<TPixel>(3))
                   .WhenInjectedInto(typeof(RgbBlurConverter), typeof(RgbEmbossingConverter),
                                     typeof(RgbSharpnessConverter))
                   .InSingletonScope();
        bindingRoot.Bind<WindowIterator<TPixel>>()
                   .ToMethod(context => new WindowIterator<TPixel>(5))
                   .WhenInjectedInto<RgbGaussConverter>()
                   .InSingletonScope(); //todo костылище
    }

    private static void ConfigurePixelIterators<TPixel>(IBindingRoot bindingRoot)
        where TPixel : IPixel
    {
        bindingRoot.Bind(syntax => syntax.FromThisAssembly()
                                         .SelectAllClasses()
                                         .InheritedFrom<IPixelConverter<TPixel, TPixel>>()
                                         .BindAllInterfaces()
                                         .Configure(x => x.InSingletonScope()));
        bindingRoot.Bind(syntax => syntax.FromThisAssembly()
                                         .SelectAllClasses()
                                         .InheritedFrom<IPixelConverter<TPixel[,], TPixel>>()
                                         .BindAllInterfaces()
                                         .Configure(x => x.InSingletonScope()));
    }

    private static void ConfigureRgbConverters(IBindingRoot bindingRoot)
    {
        bindingRoot.Bind<IConverter<RgbPixel>>().To<RgbBlurConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter<RgbPixel>>().To<RgbEmbossingConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter<RgbPixel>>().To<RgbGaussConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter<RgbPixel>>().To<RgbGrayScaleConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter<RgbPixel>>().To<RgbMedianConverter>().InSingletonScope();
        bindingRoot.Bind<IConverter<RgbPixel>>().To<RgbSharpnessConverter>().InSingletonScope();
    }
}