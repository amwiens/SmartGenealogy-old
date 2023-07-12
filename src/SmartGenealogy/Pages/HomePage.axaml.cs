using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = new HomePageViewModel();
        }
    }
}