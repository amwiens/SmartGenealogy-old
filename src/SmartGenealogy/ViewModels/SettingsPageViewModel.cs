﻿using SmartGenealogy.AppSettings;

namespace SmartGenealogy.ViewModels;

public partial class SettingsPageViewModel : BaseViewModel
{
    private readonly Services.FilePicker _filePicker;

    [ObservableProperty]
    string modelPath;

    [ObservableProperty]
    FileResult file;

    [ObservableProperty]
    ThemePalette selectedPrimaryColorItem;

    public SettingsPageViewModel()
    {
        _filePicker = Services.FilePicker.Instance;
        LoadSettings();
    }

    [RelayCommand]
    private async Task OpenFileAsync()
    {
        File = await _filePicker.OpenModelPickerAsync();
        if (File != null)
        {
            ModelPath = File.FullPath;
            AppSettings.AppSettings.ModelPath = ModelPath;
        }
    }

    private void LoadSettings()
    {
        ModelPath = AppSettings.AppSettings.ModelPath;
    }
}
