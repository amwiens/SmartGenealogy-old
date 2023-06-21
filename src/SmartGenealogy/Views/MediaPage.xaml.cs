namespace SmartGenealogy.Views;

public partial class MediaPage : ContentPage
{
	public MediaPage()
	{
		InitializeComponent();
		BindingContext = new MediaPageViewModel();
	}
}