namespace SmartGenealogy.Maui.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class PersonViewModel : ViewModelBase
{
    

    public string Id { get; set; }

    [ObservableProperty]
    Person person;

    public string Name => $"{Person?.GivenName} {Person?.Surname}";

    public PersonViewModel()
    {
        
    }

    [RelayCommand]
    private void OpenWindow()
    {
        var secondWindow = new Window
        {
            Page = new PersonPage(this),
        };

        Application.Current.OpenWindow(secondWindow);
    }

    internal async Task InitializeAsync()
    {
        if (Person != null)
            return;

        Person = new Person { Id = Guid.NewGuid(), GivenName = "Chloe", Surname = "Wiens", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
    }
}