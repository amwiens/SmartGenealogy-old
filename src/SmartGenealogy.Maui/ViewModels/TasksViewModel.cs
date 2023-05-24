namespace SmartGenealogy.Maui.ViewModels;

public partial class TasksViewModel : ViewModelBase
{
    [ObservableProperty]
    string textToSearch;

    public TasksViewModel()
    {

    }

    public async Task InitializeAsync()
    {

    }

    [RelayCommand]
    async Task Search()
    {
        IEnumerable<TaskItem> list;
        if (string.IsNullOrWhiteSpace(TextToSearch))
        {

        }
    }
}