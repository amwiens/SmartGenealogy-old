using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;

using Material.Styles.Controls;

namespace SmartGenealogy.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TemplatedControl_OnTemplateApplied(object? sender, TemplateAppliedEventArgs e)
    {
        SnackbarHost.Post("Welcome to demo of Material.Avalonia!", "Root", DispatcherPriority.Background);
    }
}