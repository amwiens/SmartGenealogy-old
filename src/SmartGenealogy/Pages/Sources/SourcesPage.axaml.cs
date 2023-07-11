using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class SourcesPage : UserControl
    {
        public SourcesPage()
        {
            InitializeComponent();
            DataContext = new SourcesPageViewModel();
        }
    }
}