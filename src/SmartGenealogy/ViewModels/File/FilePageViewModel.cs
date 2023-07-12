using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using SmartGenealogy.Messages;

using System.Diagnostics;

namespace SmartGenealogy.ViewModels;

public partial class FilePageViewModel : MainPageViewModelBase
{
    private AppSettings.AppSettings _appSettings => AppSettings.AppSettings.Instance;

    [RelayCommand]
    private void OpenFile()
    {
        _appSettings.FilePath = "test";
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(true));
        Debug.WriteLine("File Open");
    }

    [RelayCommand]
    private void CloseFile()
    {
        _appSettings.FilePath = null;
        WeakReferenceMessenger.Default.Send(new OpenFileChangedMessage(false));
        Debug.WriteLine("File Closed");
    }
}