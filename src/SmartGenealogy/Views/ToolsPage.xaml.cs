namespace SmartGenealogy.Views;

public partial class ToolsPage : ContentPage
{
	public ToolsPage()
	{
		InitializeComponent();
		BindingContext = new ToolsPageViewModel();
	}
}