namespace SmartGenealogy.ViewModels;

public partial class FilePageViewModel : BaseViewModel
{

    public FilePageViewModel()
    {

    }

    [RelayCommand]
    public void NewFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage("ar-AE"));
    }

    [RelayCommand]
    public void OpenFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage("ar-AE"));
    }

    [RelayCommand]
    public void RestoreFile()
    {
        WeakReferenceMessenger.Default.Send(new OpenFileMessage("ar-AE"));
    }
}