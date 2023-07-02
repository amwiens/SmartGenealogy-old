using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Models;

public class MainAppSearchItem
{
    public MainAppSearchItem() { }

    public MainAppSearchItem(string pageHeader, Type pageType)
    {
        Header = pageHeader;
        PageType = pageType;
    }

    public string Header { get; set; }

    public PageBaseViewModel ViewModel { get; set; }

    public string Namespace { get; set; }

    public Type PageType { get; set; }
}