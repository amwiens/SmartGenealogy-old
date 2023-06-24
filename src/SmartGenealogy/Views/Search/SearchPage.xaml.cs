namespace SmartGenealogy.Views;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();
        BindingContext = new SearchPageViewModel();
    }
}