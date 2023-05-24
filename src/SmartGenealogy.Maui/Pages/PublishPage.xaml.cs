namespace SmartGenealogy.Maui.Pages;

public partial class PublishPage : ContentPage
{
	private PublishViewModel viewModel => BindingContext as PublishViewModel;

	public PublishPage(PublishViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}