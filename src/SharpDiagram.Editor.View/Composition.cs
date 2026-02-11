using Microsoft.Extensions.DependencyInjection;

namespace SharpDiagram.Editor.View;

public static class Composition
{
    public static IServiceCollection AddViews(this IServiceCollection sc) => sc.AddTransient<MainWindow>();
}