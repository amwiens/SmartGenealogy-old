namespace SmartGenealogy.Views;

public partial class HomePage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}