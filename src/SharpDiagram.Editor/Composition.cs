using Microsoft.Extensions.DependencyInjection;
using SharpDiagram.Editor.View;
using SharpDiagram.Editor.ViewModel;

namespace SharpDiagram.Editor;

internal static class Composition
{
    internal static IServiceCollection Compose(this IServiceCollection sc) => sc.AddViews().AddViewModels();
}