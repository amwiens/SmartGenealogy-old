namespace SmartGenealogy.Views;

public partial class AddressesPage : ContentPage
{
    public AddressesPage()
    {
        InitializeComponent();
        BindingContext = new AddressesPageViewModel();
    }
}