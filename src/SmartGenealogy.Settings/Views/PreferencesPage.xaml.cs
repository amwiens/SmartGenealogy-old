using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using SmartGenealogy.Settings.Models;
using SmartGenealogy.Settings.ViewModels;

using System.Collections.ObjectModel;

namespace SmartGenealogy.Settings.Views;

public sealed partial class PreferencesPage : Page
{
    public PreferencesViewModel ViewModel
    {
        get;
    }

    public ObservableCollection<Breadcrumb> Breadcrumbs
    {
        get;
    }

    public PreferencesPage()
    {
        ViewModel = Application.Current.GetService<PreferencesViewModel>();
        this.InitializeComponent();

        var stringResource = new StringResource("SmartGenealogy.Settings/Resources");
        Breadcrumbs = new ObservableCollection<Breadcrumb>
        {
            new Breadcrumb(stringResource.GetLocalized("Settings_Header"), typeof(SettingsViewModel).FullName!),
            new Breadcrumb(stringResource.GetLocalized("Settings_Preferences_Header"), typeof(PreferencesViewModel).FullName!),
        };
    }

    private void BreadcrumbBar_ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
    {
        if (args.Index < Breadcrumbs.Count - 1)
        {
            var crumb = (Breadcrumb)args.Item;
            crumb.NavigateTo();
        }
    }
}