using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class TasksPage : UserControl
    {
        public TasksPage()
        {
            InitializeComponent();
            DataContext = new TasksPageViewModel();
        }
    }
}