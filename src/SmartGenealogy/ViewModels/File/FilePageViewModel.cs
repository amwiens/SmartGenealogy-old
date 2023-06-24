namespace SmartGenealogy.ViewModels;

public partial class FilePageViewModel : BaseViewModel
{
    private readonly Services.FilePicker _filePicker;

    public FilePageViewModel()
    {
        _filePicker = Services.FilePicker.Instance;
    }

    [RelayCommand]
    public void NewFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage("ar-AE"));
    }

    [RelayCommand]
    public async void OpenFile()
    {
        var file = await _filePicker.OpenDatabasePickerAsync();
        if (file != null)
        {
            AppSettings.AppSettings.FilePath = file.FullPath;
            WeakReferenceMessenger.Default.Send(new OpenFileMessage(file.FullPath));
        }
    }

    [RelayCommand]
    public void RestoreFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage("ar-AE"));
    }
}