using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using Serilog;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Messages;

namespace SmartGenealogy.ViewModels.Files;

public partial class FilesViewModel : MainPageViewModelBase, IFileViewModel
{
    private readonly ILogger _logger;
    private readonly ISettingService _settingService;

    [ObservableProperty]
    private bool _isFileOpen;

    [ObservableProperty]
    private string? _currentFile;

    public FilesViewModel(ISettingService settingService,
        ILogger logger)
    {
        _logger = logger;
        _settingService = settingService;

        IsFileOpen = !string.IsNullOrEmpty(_settingService.Settings.FilePath);
        CurrentFile = _settingService.Settings.FilePath;
        _logger.Information("File view model initialized");
    }

    [RelayCommand]
    private void CreateFile()
    {
        _logger.Information("Creating file");
        _settingService.Settings.FilePath = "create";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void OpenFile()
    {
        _logger.Information("Opening file");
        _settingService.Settings.FilePath = "open";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void RestoreFile()
    {
        _logger.Information("Restoring file");
        _settingService.Settings.FilePath = "restore";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
    }

    [RelayCommand]
    private void BackupFile()
    {
        _logger.Information("Backing up file");
    }

    [RelayCommand]
    private void ImportData()
    {
        _logger.Information("Importing data");
    }

    [RelayCommand]
    private void ExportData()
    {
        _logger.Information("Exporting data");
    }

    [RelayCommand]
    private void Tools()
    {
        _logger.Information("Tools");
    }

    [RelayCommand]
    private void CloseFile()
    {
        _logger.Information("Closing file");
        _settingService.Settings.FilePath = null;
        IsFileOpen = false;
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(false));
    }
}