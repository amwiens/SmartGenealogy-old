namespace SmartGenealogy.Maui.Pages;

public partial class TasksPage : ContentPage
{
	private TasksViewModel viewModel => BindingContext as TasksViewModel;

	public TasksPage(TasksViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}