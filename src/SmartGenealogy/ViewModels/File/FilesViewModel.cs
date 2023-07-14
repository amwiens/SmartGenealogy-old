using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Messages;

namespace SmartGenealogy.ViewModels.Files;

public partial class FilesViewModel : MainPageViewModelBase, IFileViewModel
{
    private readonly ISettingService _settingService;

    [ObservableProperty]
    private bool _isFileOpen;

    [ObservableProperty]
    private string? _currentFile;

    public FilesViewModel(ISettingService settingService)
    {
        _settingService = settingService;
        IsFileOpen = !string.IsNullOrEmpty(_settingService.Settings.FilePath);
        CurrentFile = _settingService.Settings.FilePath;
    }

    [RelayCommand]
    private void CreateFile()
    {
        _settingService.Settings.FilePath = "create";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void OpenFile()
    {
        _settingService.Settings.FilePath = "open";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void RestoreFile()
    {
        _settingService.Settings.FilePath = "restore";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void BackupFile()
    {
    }

    [RelayCommand]
    private void ImportData()
    {
    }

    [RelayCommand]
    private void ExportData()
    {
    }

    [RelayCommand]
    private void Tools()
    {
    }

    [RelayCommand]
    private void CloseFile()
    {
        _settingService.Settings.FilePath = null;
        IsFileOpen = false;
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(false));
    }
}