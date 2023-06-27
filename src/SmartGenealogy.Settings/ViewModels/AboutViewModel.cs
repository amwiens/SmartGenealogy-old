using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml;

namespace SmartGenealogy.Settings.ViewModels;

public partial class AboutViewModel : ObservableObject
{
    [ObservableProperty]
    private string _versionDescription;

    public AboutViewModel()
    {
        _versionDescription = GetVersionDescription();
    }

    private static string GetVersionDescription()
    {
        IAppInfoService appInfoService = Application.Current.GetService<IAppInfoService>();
        var version = appInfoService.GetAppVersion();

        return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}