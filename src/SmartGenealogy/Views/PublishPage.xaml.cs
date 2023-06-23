namespace SmartGenealogy.Views;

public partial class PublishPage : ContentPage
{
    public PublishPage()
    {
        InitializeComponent();
        BindingContext = new PublishPageViewModel();
    }
}