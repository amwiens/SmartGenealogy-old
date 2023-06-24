namespace SmartGenealogy.Views;

public partial class FilePage : ContentPage
{
    public FilePage()
    {
        InitializeComponent();
        BindingContext = new FilePageViewModel();
    }
}