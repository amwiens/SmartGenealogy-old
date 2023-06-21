namespace SmartGenealogy.Views;

public partial class PlacesPage : ContentPage
{
	public PlacesPage()
	{
		InitializeComponent();
		BindingContext = new PlacesPageViewModel();
	}
}