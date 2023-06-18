using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.Configuration;

using SmartGenealogy.Maui.Navigation;

namespace SmartGenealogy;

public partial class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IFilePicker _filePicker;
    AppSettings.AppSettings _settings;

    [ObservableProperty]
    string modelPath;

    [ObservableProperty]
    FileResult file;

    public SettingsPageViewModel(IAppNavigator appNavigator,
        IConfiguration configuration,
        IFilePicker filePicker)
        : base(appNavigator)
    {
        _filePicker = filePicker;
        _settings = configuration.GetRequiredSection("AppSettings").Get<AppSettings.AppSettings>();
        LoadSettings();
    }

    [RelayCommand]
    private async Task OpenFileAsync()
    {
        File = await _filePicker.OpenMediaPickerAsync();
        ModelPath = File.FullPath;
    }

    private void LoadSettings()
    {
        ModelPath = Preferences.Default.Get<string>("ModelPath", string.Empty);
    }
}
