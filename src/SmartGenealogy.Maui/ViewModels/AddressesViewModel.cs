namespace SmartGenealogy.Maui.ViewModels;

public partial class AddressesViewModel : ViewModelBase
{
    [ObservableProperty]
    string textToSearch;

    public AddressesViewModel()
    {

    }

    public async Task InitializeAsync()
    {

    }

    [RelayCommand]
    async Task Search()
    {
        IEnumerable<Address> list;
        if (string.IsNullOrWhiteSpace(TextToSearch))
        {

        }
    }
}