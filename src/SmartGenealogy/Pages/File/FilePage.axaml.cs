using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class FilePage : UserControl
    {
        public FilePage()
        {
            InitializeComponent();
            DataContext = new FilePageViewModel();
        }
    }
}