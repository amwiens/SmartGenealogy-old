namespace SmartGenealogy.Views;

public partial class SourcesPage : ContentPage
{
	public SourcesPage()
	{
		InitializeComponent();
		BindingContext = new SourcesPageViewModel();
	}
}