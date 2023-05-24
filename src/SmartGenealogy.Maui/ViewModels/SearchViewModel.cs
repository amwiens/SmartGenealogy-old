using Microsoft.Maui.Controls.Platform.Compatibility;

namespace SmartGenealogy.Maui.ViewModels;

public partial class SearchViewModel : ViewModelBase
{
    public ICommand PerformSearch => new Command<string>((string query) =>
    {
        //SearchResults = new List<string>
        //{
        //    "test",
        //    query,
        //    "Aaron"
        //};
    });

    [ObservableProperty]
    private List<string> searchResults;
}