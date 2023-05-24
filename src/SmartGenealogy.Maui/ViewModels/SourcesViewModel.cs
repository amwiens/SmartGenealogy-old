namespace SmartGenealogy.Maui.ViewModels;

public partial class SourcesViewModel : ViewModelBase
{
    [ObservableProperty]
    string textToSearch;

    public SourcesViewModel()
    {

    }

    public async Task InitializeAsync()
    {

    }

    [RelayCommand]
    async Task Search()
    {
        IEnumerable<Source> list;
        if (string.IsNullOrWhiteSpace(TextToSearch))
        {

        }
    }
}