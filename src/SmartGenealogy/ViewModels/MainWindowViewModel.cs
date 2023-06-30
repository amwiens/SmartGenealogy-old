using Aura.UI.Data;

using ReactiveUI;

using System.Collections.ObjectModel;

namespace SmartGenealogy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<INavigationViewItemTemplate> _navigationViewsItems;

    public MainWindowViewModel()
    {
        _navigationViewsItems = new();


    }

    public ObservableCollection<INavigationViewItemTemplate> Items
    {
        get => _navigationViewsItems;
        set => this.RaiseAndSetIfChanged(ref _navigationViewsItems, value);
    }
}