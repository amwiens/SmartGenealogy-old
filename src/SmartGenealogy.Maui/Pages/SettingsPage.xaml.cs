namespace SmartGenealogy.Maui.Pages;

public partial class SettingsPage : ContentPage
{
	private SettingsViewModel viewModel => BindingContext as SettingsViewModel;

	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}