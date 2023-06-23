namespace SmartGenealogy.Views;

public partial class ChatDetailPage : ContentPage
{
    public ChatDetailPage()
    {
        InitializeComponent();
        BindingContext = new ChatDetailPageViewModel();
    }
}