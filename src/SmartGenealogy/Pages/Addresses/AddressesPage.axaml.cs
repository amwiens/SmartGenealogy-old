using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class AddressesPage : UserControl
    {
        public AddressesPage()
        {
            InitializeComponent();
            DataContext = new AddressesPageViewModel();
        }
    }
}