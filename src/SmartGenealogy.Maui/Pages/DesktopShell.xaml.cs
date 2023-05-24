namespace SmartGenealogy.Maui.Pages;

public partial class DesktopShell
{
	public DesktopShell()
	{
		InitializeComponent();

		BindingContext = new ShellViewModel();
	}
}