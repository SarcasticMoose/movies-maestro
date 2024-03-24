using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Logging;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using DryIoc;
using Microsoft.Extensions.Logging;
using MoviesMaestro.Extentions;
using MoviesMaestro.Providers;
using MoviesMaestro.ViewModels;
using MoviesMaestro.Views;
using System.Xml.Linq;

namespace MoviesMaestro;

public partial class App : Application
{
    private IContainer? _container;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        if (Design.IsDesignMode)
        {
            RequestedThemeVariant = ThemeVariant.Dark;
        }
    }

    public override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.RemoveAt(0);

        var mainViewModel = _container.Resolve<MainViewModel>();


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public override void RegisterServices()
    {
        _container = new ContainerProvider().Get();

        _container?.RegisterFileSystem();
        _container?.RegisterProviders();
        _container?.RegisterLogger();
        _container?.RegisterRouter();
        _container?.RegisterViewModels();

        base.RegisterServices();
    }
}
