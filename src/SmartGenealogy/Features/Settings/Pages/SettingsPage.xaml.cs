namespace SmartGenealogy;

public partial class SettingsPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}