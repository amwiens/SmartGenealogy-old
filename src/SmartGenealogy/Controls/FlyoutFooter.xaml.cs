namespace SmartGenealogy.Controls;

public partial class FlyoutFooter : ContentView
{
    public FlyoutFooter()
    {
        InitializeComponent();

        labelVersion.Text = "Version" + " " + AppInfo.Current.VersionString;
    }
}