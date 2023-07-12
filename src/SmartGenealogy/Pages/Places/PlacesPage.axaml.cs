using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class PlacesPage : UserControl
    {
        public PlacesPage()
        {
            InitializeComponent();
            DataContext = new PlacesPageViewModel();
        }
    }
}