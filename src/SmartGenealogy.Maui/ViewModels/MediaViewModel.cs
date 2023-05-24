namespace SmartGenealogy.Maui.ViewModels;

public partial class MediaViewModel : ViewModelBase
{
    [ObservableProperty]
    string textToSearch;

    public MediaViewModel()
    {

    }

    public async Task InitializeAsync()
    {

    }

    [RelayCommand]
    async Task Search()
    {
        IEnumerable<Media> list;
        if (string.IsNullOrWhiteSpace(TextToSearch))
        {

        }
    }
}