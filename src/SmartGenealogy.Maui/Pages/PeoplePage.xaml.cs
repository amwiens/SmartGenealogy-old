namespace SmartGenealogy.Maui.Pages;

public partial class PeoplePage : ContentPage
{
	private PeopleViewModel viewModel => BindingContext as PeopleViewModel;

	public PeoplePage(PeopleViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await viewModel.InitializeAsync();
    }
}