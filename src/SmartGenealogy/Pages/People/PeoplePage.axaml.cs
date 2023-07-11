using Avalonia.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Pages
{
    public partial class PeoplePage : UserControl
    {
        public PeoplePage()
        {
            InitializeComponent();
            DataContext = new PeoplePageViewModel();
        }
    }
}