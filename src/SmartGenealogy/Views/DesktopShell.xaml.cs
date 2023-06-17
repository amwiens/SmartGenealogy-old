namespace SmartGenealogy.Views;

public partial class DesktopShell : Shell
{
    public DesktopShell()
    {
        InitializeComponent();
        BindingContext = new DesktopShellViewModel();
    }
}