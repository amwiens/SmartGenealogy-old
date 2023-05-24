namespace SmartGenealogy.Maui.Pages;

public partial class PersonPage
{
	private PersonViewModel viewModel => BindingContext as PersonViewModel;

	public PersonPage(PersonViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await viewModel.InitializeAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}