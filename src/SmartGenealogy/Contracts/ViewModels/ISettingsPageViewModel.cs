using Avalonia.Styling;

using System.Collections.ObjectModel;

namespace SmartGenealogy.Contracts.ViewModels;

public interface ISettingsPageViewModel
{
    ObservableCollection<ThemeVariant> AppThemes { get; }
}