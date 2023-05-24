namespace SmartGenealogy.Maui.Pages;

public partial class SearchPage : ContentPage
{
	private SearchViewModel viewModel => BindingContext as SearchViewModel;

	public SearchPage(SearchViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}