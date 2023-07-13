namespace SmartGenealogy.ViewModels.Home;

public partial class HomeNavPageViewModel
{
    public HomeNavPageViewModel()
    { }

    public HomeNavPageViewModel(string title, Uri uri)
    {
        Title = title;
        NavigateURI = uri;
    }

    public string Title { get; set; }

    public string? ImageUri { get; set; }

    public Uri NavigateURI { get; set; }
}