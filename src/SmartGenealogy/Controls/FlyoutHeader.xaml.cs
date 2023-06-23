namespace SmartGenealogy.Controls;

public partial class FlyoutHeader : ContentView
{
    public FlyoutHeader()
    {
        InitializeComponent();

        labelVersion.Text = "Version" + " " + AppInfo.Current.VersionString;
    }
}