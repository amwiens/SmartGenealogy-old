using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using Serilog;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Messages;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Files;

public partial class FilesViewModel : MainPageViewModelBase, IFileViewModel
{
    private readonly ILogger _logger;
    private readonly ISettingService _settingService;
    public IMessageBoxService MessageBoxService { get; init; }

    [ObservableProperty]
    private bool _isFileOpen;

    [ObservableProperty]
    private string? _currentFile;

    public FilesViewModel(ISettingService settingService,
        ILogger logger)
    {
        _logger = logger;
        _settingService = settingService;

        NavHeader = XAML_Navigation_File;

        IsFileOpen = !string.IsNullOrEmpty(_settingService.Settings.FilePath);
        CurrentFile = $"{XAML_FilePage_CurrentFile} {_settingService.Settings.FilePath}";
        _logger.Information("File view model initialized");
    }

    [RelayCommand]
    private async Task CreateFile()
    {
        _logger.Information("Creating file");
        _settingService.Settings.FilePath = "create";
        IsFileOpen = true;
        CurrentFile = $"{XAML_FilePage_CurrentFile} {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
        await MessageBoxService.CreateSuccessMessageBox("File created");
    }

    [RelayCommand]
    private async Task OpenFile()
    {
        _logger.Information("Opening file");
        _settingService.Settings.FilePath = "open";
        IsFileOpen = true;
        CurrentFile = $"Current File: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
        await MessageBoxService.CreateSuccessMessageBox("File opened");
    }

    [RelayCommand]
    private async Task RestoreFile()
    {
        _logger.Information("Restoring file");
        _settingService.Settings.FilePath = "restore";
        IsFileOpen = true;
        CurrentFile = $"CurrentFile: {_settingService.Settings.FilePath}";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
        await MessageBoxService.CreateSuccessMessageBox("File restored");
    }

    [RelayCommand]
    private async Task BackupFile()
    {
        _logger.Information("Backing up file");
        await MessageBoxService.CreateSuccessMessageBox("File backed up");
    }

    [RelayCommand]
    private async Task ImportData()
    {
        _logger.Information("Importing data");
        await MessageBoxService.CreateSuccessMessageBox("Data imported");
    }

    [RelayCommand]
    private async Task ExportData()
    {
        _logger.Information("Exporting data");
        await MessageBoxService.CreateSuccessMessageBox("Data exported");
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