using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = new SettingsPageViewModel();
        }
    }
}