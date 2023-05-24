namespace SmartGenealogy.Maui.Pages;

public partial class FilePage : ContentPage
{
	private FileViewModel fileViewModel => BindingContext as FileViewModel;

	public FilePage(FileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}