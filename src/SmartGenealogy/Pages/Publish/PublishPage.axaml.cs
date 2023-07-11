using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class PublishPage : UserControl
    {
        public PublishPage()
        {
            InitializeComponent();
            DataContext = new PublishPageViewModel();
        }
    }
}