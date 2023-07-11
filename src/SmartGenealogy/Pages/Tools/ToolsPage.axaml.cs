using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class ToolsPage : UserControl
    {
        public ToolsPage()
        {
            InitializeComponent();
            DataContext = new ToolsPageViewModel();
        }
    }
}