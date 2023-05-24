namespace SmartGenealogy.Maui.Pages;

public partial class MediaPage : ContentPage
{
	private MediaViewModel viewModel => BindingContext as MediaViewModel;

	public MediaPage(MediaViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}