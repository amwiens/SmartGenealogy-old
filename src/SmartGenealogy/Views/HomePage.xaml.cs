namespace SmartGenealogy.Views;

public partial class HomePage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
	}
}