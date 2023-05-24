namespace SmartGenealogy.Maui.ViewModels;

public partial class PlacesViewModel : ViewModelBase
{
    [ObservableProperty]
    string textToSearch;

    public PlacesViewModel()
    {

    }

    public async Task InitializeAsync()
    {

    }

    [RelayCommand]
    async Task Search()
    {
        IEnumerable<Place> list;
        if (string.IsNullOrWhiteSpace(TextToSearch))
        {

        }
    }
}