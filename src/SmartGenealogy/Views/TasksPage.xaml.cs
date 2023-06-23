namespace SmartGenealogy.Views;

public partial class TasksPage : ContentPage
{
    public TasksPage()
    {
        InitializeComponent();
        BindingContext = new TasksPageViewModel();
    }
}