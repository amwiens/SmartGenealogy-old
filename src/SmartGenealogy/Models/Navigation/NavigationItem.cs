using CommunityToolkit.Mvvm.ComponentModel;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Models;

public partial class NavigationItem : NavigationItemBase
{
    public readonly string? Name;
    
    [ObservableProperty]
    private string? _displayName;

    public ViewModelBase ViewModel { get; set; }

    public NavigationItem(ViewModelBase viewModel, string displayName, string name)
    {
        ViewModel = viewModel;
        DisplayName = displayName;
        Name = name;
    }
}