using SmartGenealogy.Models;

using System.Collections.ObjectModel;

namespace SmartGenealogy.Contracts.ViewModels;

public interface IMainWindowViewModel
{
    ObservableCollection<NavigationItem> NavigationItems { get; }

    ObservableCollection<NavigationItem> FooterItems { get; }
}