using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Hosting;
using ReactiveUI;
using ReactiveUI.Avalonia;
using SharpDiagram.Editor.ViewModels;
using SharpDiagram.Editor.Views;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace SharpDiagram.Editor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var hostBuilder = new HostBuilder()
            .ConfigureLogging(builder =>
            {
                builder.ClearProviders();
            })
            .UseNLog()
            .ConfigureServices((context, services) =>
            {
                services.UseMicrosoftDependencyResolver();
                var resolver = Locator.CurrentMutable;
                resolver.InitializeSplat();

                Locator.CurrentMutable.RegisterConstant(new AvaloniaActivationForViewFetcher(),
                    typeof(IActivationForViewFetcher));
                Locator.CurrentMutable.RegisterConstant(new AutoDataTemplateBindingHook(),
                    typeof(IPropertyBindingHook));
                RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
                services.Compose();
            });

        var host = hostBuilder.Build();
        host.Services.UseMicrosoftDependencyResolver();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = host.Services.GetRequiredService<MainWindow>();
            var vm = host.Services.GetRequiredService<MainWindowViewModel>();
            window.DataContext = vm;

            desktop.MainWindow = window;
            desktop.MainWindow.Show();

            desktop.Exit += async (_, _) =>
            {
                using (host)
                {
                    await host.StopAsync();
                }
            };
        }
        // I have deleted the mobile app because I'm using MainViewModel 
        // with data model so the code would not work either way

        base.OnFrameworkInitializationCompleted();
    }
}