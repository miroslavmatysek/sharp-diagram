using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using SharpDiagram.Editor.ViewModel;

namespace SharpDiagram.Editor.View;

public static class Composition
{
    public static IServiceCollection AddViews(this IServiceCollection sc) =>
        sc.AddTransient<IViewFor<MainWindowViewModel>, MainWindow>();
}