namespace SmartGenealogy.Views;

public partial class DesktopShell : FlyoutPage
{
    public DesktopShell()
    {
        InitializeComponent();

        Flyout = new MainMenuPage(LaunchPageInDetail);
    }

    private void LaunchPageInDetail(Page page)
    {
        Detail = page;
        IsPresented = false;
    }
}