namespace SmartGenealogy.ViewModels;

public partial class FilePageViewModel : BaseViewModel
{
    private readonly Services.FilePicker _filePicker;

    [ObservableProperty]
    private bool _fileOpen = !string.IsNullOrEmpty(AppSettings.AppSettings.FilePath);

    public FilePageViewModel()
    {
        _filePicker = Services.FilePicker.Instance;
    }

    [RelayCommand]
    public void NewFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage(string.Empty));
        FileOpen = !string.IsNullOrEmpty(AppSettings.AppSettings.FilePath);
    }

    [RelayCommand]
    public async void OpenFile()
    {
        var file = await _filePicker.OpenDatabasePickerAsync();
        if (file != null)
        {
            AppSettings.AppSettings.FilePath = file.FullPath;
            FileOpen = !string.IsNullOrEmpty(AppSettings.AppSettings.FilePath);
            WeakReferenceMessenger.Default.Send(new OpenFileMessage(file.FullPath));
        }
    }

    [RelayCommand]
    public void RestoreFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage(string.Empty));
        FileOpen = !FileOpen;
    }

    [RelayCommand]
    public void BackupFile()
    {
        
    }

    [RelayCommand]
    public void ImportData()
    {
        
    }

    [RelayCommand]
    public void ExportData()
    {
        
    }

    [RelayCommand]
    public void ToolsFile()
    {
        
    }

    [RelayCommand]
    public void CloseFile()
    {
        AppSettings.AppSettings.FilePath = string.Empty;
        WeakReferenceMessenger.Default.Send(new OpenFileMessage(string.Empty));
        FileOpen = false;
    }
}