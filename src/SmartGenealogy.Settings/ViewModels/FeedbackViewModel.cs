using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;

using System.Threading.Tasks;

namespace SmartGenealogy.Settings.ViewModels;

public partial class FeedbackViewModel : ObservableObject
{
    private readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _elementTheme;

    [ObservableProperty]
    private string _versionDescription;

    public FeedbackViewModel(IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;
        _versionDescription = GetVersionDescription();
    }

    [RelayCommand]
    private async Task SwitchThemeAsync(ElementTheme theme)
    {
        if (ElementTheme != theme)
        {
            ElementTheme = theme;

            await _themeSelectorService.SetThemeAsync(theme);
        }
    }

    private static string GetVersionDescription()
    {
        IAppInfoService appINfoService = Application.Current.GetService<IAppInfoService>();
        var localizedAppName = appINfoService.GetAppNameLocalized();
        var version = appINfoService.GetAppVersion();

        return $"{localizedAppName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}