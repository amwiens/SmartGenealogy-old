using Avalonia;
using Avalonia.Styling;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.ViewModels;

public partial class SettingsPageViewModel : MainPageViewModelBase
{
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
        }
    }

    public SettingsPageViewModel()
    {
        CurrentAppTheme = Application.Current.ActualThemeVariant;
    }
}