using Microsoft.Extensions.DependencyInjection;

namespace SharpDiagram.Editor.ViewModel;

public static class Composition
{
    public static IServiceCollection AddViewModels(this IServiceCollection sc) => sc.AddTransient<MainWindowViewModel>();
}