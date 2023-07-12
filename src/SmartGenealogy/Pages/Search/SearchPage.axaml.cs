using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class SearchPage : UserControl
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = new SearchPageViewModel();
        }
    }
}