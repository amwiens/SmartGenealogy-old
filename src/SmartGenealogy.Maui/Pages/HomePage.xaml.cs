namespace SmartGenealogy.Maui.Pages;

public partial class HomePage : ContentPage
{
	private HomeViewModel viewModel => BindingContext as HomeViewModel;

	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}