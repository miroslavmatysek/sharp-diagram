using ReactiveUI.Avalonia;
using SharpDiagram.Editor.ViewModel;

namespace SharpDiagram.Editor.View;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}