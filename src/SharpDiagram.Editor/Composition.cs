using Microsoft.Extensions.DependencyInjection;
using SharpDiagram.Editor.ViewModels;
using SharpDiagram.Editor.Views;

namespace SharpDiagram.Editor;

internal static class Composition
{
    internal static IServiceCollection Compose(this IServiceCollection sc) => sc.AddViews().AddViewModels();
    
    private static IServiceCollection AddViews(this IServiceCollection sc) => sc.AddTransient<MainWindow>();
    
    private static IServiceCollection AddViewModels(this IServiceCollection sc) => sc.AddTransient<MainWindowViewModel>();
}