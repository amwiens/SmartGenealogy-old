using SmartGenealogy.Constants;
using SmartGenealogy.Views;

namespace SmartGenealogy;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        if (Settings.IsDesktop)
        {
            MainPage = new DesktopShell();
        }
        else
        {
            MainPage = new MobileShell();
        }
    }
}