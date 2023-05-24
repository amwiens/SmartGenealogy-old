namespace SmartGenealogy.Maui.Pages;

public partial class SourcesPage : ContentPage
{
	private SourcesViewModel viewModel => BindingContext as SourcesViewModel;

	public SourcesPage(SourcesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}