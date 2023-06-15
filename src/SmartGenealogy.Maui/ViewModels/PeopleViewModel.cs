namespace SmartGenealogy.Maui.ViewModels;

public partial class PeopleViewModel : ViewModelBase
{
    private readonly PeopleService _peopleService;

    [ObservableProperty]
    string textToSearch;

    [ObservableProperty]
    List<Person> people;

    [ObservableProperty]
    Person selectedPerson;

    public PeopleViewModel(PeopleService people)
    {
        _peopleService = people;
    }

    public async Task InitializeAsync()
    {
        var people = await _peopleService.GetAllPeople();

        if (People != null)
            People.Clear();
        People = people?.ToList();
    }

    [RelayCommand]
    async Task Search()
    {
        IEnumerable<Person> list;
        if (string.IsNullOrWhiteSpace(TextToSearch))
        {
            //list = await
        }
    }

    [RelayCommand]
    Task TapPerson(Person person) => Shell.Current.GoToAsync($"{nameof(PersonPage)}?Id={person.Id}");
}