namespace SmartGenealogy.Maui.Pages;

public partial class ToolsPage : ContentPage
{
	private ToolsViewModel viewModel => BindingContext as ToolsViewModel;

	public ToolsPage(ToolsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}