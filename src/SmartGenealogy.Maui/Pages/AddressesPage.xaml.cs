namespace SmartGenealogy.Maui.Pages;

public partial class AddressesPage : ContentPage
{
	private AddressesViewModel viewModel => BindingContext as AddressesViewModel;

	public AddressesPage(AddressesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}