namespace SmartGenealogy.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
		BindingContext = new AboutPageViewModel();
	}
}