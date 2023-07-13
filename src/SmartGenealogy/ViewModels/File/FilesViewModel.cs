using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Messages;

namespace SmartGenealogy.ViewModels.Files;

public partial class FilesViewModel : MainPageViewModelBase, IFileViewModel
{
    private AppSettings.AppSettings _appSettings => AppSettings.AppSettings.Instance;

    [ObservableProperty]
    private bool _isFileOpen;

    [ObservableProperty]
    private string? _currentFile;

    [RelayCommand]
    private void CreateFile()
    {
        _appSettings.FilePath = "create";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_appSettings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void OpenFile()
    {
        _appSettings.FilePath = "open";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_appSettings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void RestoreFile()
    {
        _appSettings.FilePath = "restore";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_appSettings.FilePath}";
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
        _appSettings.FilePath = null;
        IsFileOpen = false;
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(false));
    }
}