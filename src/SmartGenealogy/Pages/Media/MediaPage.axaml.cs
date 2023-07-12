using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class MediaPage : UserControl
    {
        public MediaPage()
        {
            InitializeComponent();
            DataContext = new MediaPageViewModel();
        }
    }
}