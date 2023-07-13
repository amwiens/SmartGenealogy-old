using Avalonia;
using Avalonia.Styling;

using CommunityToolkit.Mvvm.ComponentModel;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Settings;

public partial class SettingsPageViewModel : MainPageViewModelBase, ISettingsPageViewModel
{
    private AppSettings.AppSettings _appSettings => AppSettings.AppSettings.Instance;

    [ObservableProperty]
    private string _currentVersion = typeof(SmartGenealogy.Controls.PageHeaderControl).Assembly.GetName().Version?.ToString();

    [ObservableProperty]
    private ThemeVariant[] _appThemes = new[] { ThemeVariant.Default, ThemeVariant.Light, ThemeVariant.Dark };

    [ObservableProperty]
    private ThemeVariant _currentAppTheme;

    partial void OnCurrentAppThemeChanged(ThemeVariant? oldValue, ThemeVariant newValue)
    {
        if (oldValue != newValue && Application.Current.ActualThemeVariant != newValue)
        {
            Application.Current.RequestedThemeVariant = newValue;
            _appSettings.CurrentTheme = newValue;
        }
    }

    public SettingsPageViewModel()
    {
        CurrentAppTheme = Application.Current.ActualThemeVariant;
    }
}