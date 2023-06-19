namespace SmartGenealogy.ViewModels;

public partial class SettingsPageViewModel : BaseViewModel
{
    private readonly IFilePicker _filePicker;

    [ObservableProperty]
    string modelPath;

    [ObservableProperty]
    FileResult file;

    public SettingsPageViewModel()
    {
        LoadSettings();
    }

    public SettingsPageViewModel(IFilePicker filePicker)
    {
        _filePicker = filePicker;
        LoadSettings();
    }

    [RelayCommand]
    private async Task OpenFileAsync()
    {
        File = await _filePicker.OpenMediaPickerAsync();
        ModelPath = File.FullPath;
        AppSettings.AppSettings.ModelPath = ModelPath;
    }

    private void LoadSettings()
    {
        ModelPath = AppSettings.AppSettings.ModelPath;
    }
}
