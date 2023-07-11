using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;

using CommunityToolkit.Mvvm.ComponentModel;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.Models;
using SmartGenealogy.Services;

namespace SmartGenealogy.ViewModels;

public partial class MainViewViewModel : ViewModelBase
{
    [ObservableProperty]
    private Control _currentPage;

    [ObservableProperty]
    private Category _selectedCategory;

    partial void OnSelectedCategoryChanged(Category? oldValue, Category newValue)
    {
        SetCurrentPage();
    }

    [ObservableProperty]
    private List<Category> _categories = new List<Category>();

    [ObservableProperty]
    private List<Category> _footerItems = new List<Category>();

    public MainViewViewModel()
    {
        NavigationFactory = new NavigationFactory(this);

        Categories.Add(new Category { Name = "Home", Icon = Symbol.Home, ToolTip = "Dashboard" });
        Categories.Add(new Category { Name = "File", Icon = Symbol.Document, ToolTip = "File" });
        Categories.Add(new Category { Name = "People", Icon = Symbol.People, ToolTip = "People" });
        Categories.Add(new Category { Name = "Places", Icon = Symbol.Earth, ToolTip = "Places" });
        Categories.Add(new Category { Name = "Sources", Icon = Symbol.Library, ToolTip = "Sources" });
        Categories.Add(new Category { Name = "Media", Icon = Symbol.Image, ToolTip = "Media" });
        Categories.Add(new Category { Name = "Tasks", Icon = Symbol.ShowResults, ToolTip = "Tasks" });
        Categories.Add(new Category { Name = "Addresses", Icon = Symbol.ContactInfo, ToolTip = "Addresses" });
        Categories.Add(new Category { Name = "Search", Icon = Symbol.Find, ToolTip = "Search" });
        Categories.Add(new Category { Name = "Publish", Icon = Symbol.Print, ToolTip = "Publish" });
        Categories.Add(new Category { Name = "Tools", Icon = Symbol.Repair, ToolTip = "Tools" });

        FooterItems.Add(new Category { Name = "Settings", Icon = Symbol.Settings, ToolTip = "Settings" });

        SelectedCategory = Categories[0];
    }

    public NavigationFactory NavigationFactory { get; }

    public AvaloniaList<MainAppSearchItem> SearchTerms { get; } = new AvaloniaList<MainAppSearchItem>();

    public void BuildSearchTerms(MainPageViewModelBase pageItem)
    {
    }

    private void SetCurrentPage()
    {
        if (SelectedCategory is Category cat)
        {
            var smpPage = $"SmartGenealogy.Pages.{SelectedCategory.Name}Page";
            var pg = Activator.CreateInstance(Type.GetType(smpPage));
            CurrentPage = (Control)pg;
        }
        //else if (SelectedCategory is NavigationViewItem nvi)
        //{

        //}
    }
}

public abstract class CategoryBase { }

public class Category : CategoryBase
{
    public string? Name { get; set; }

    public string? ToolTip { get; set; }

    public Symbol Icon { get; set; }
}

public class Separator : CategoryBase
{

}

public class MenuItemTemplateSelector : DataTemplateSelector
{
    [Content]
    public IDataTemplate? ItemTemplate { get; set; }

    public IDataTemplate? SeparatorTemplate { get; set; }

    protected override IDataTemplate SelectTemplateCore(object item)
    {
        return item is Separator ? SeparatorTemplate : ItemTemplate;
    }
}