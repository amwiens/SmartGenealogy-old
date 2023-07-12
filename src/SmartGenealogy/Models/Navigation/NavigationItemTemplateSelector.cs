using Avalonia.Controls.Templates;
using Avalonia.Metadata;

using FluentAvalonia.UI.Controls;

namespace SmartGenealogy.Models;

public class NavigationItemTemplateSelector : DataTemplateSelector
{
    [Content]
    public IDataTemplate? ItemTemplate { get; set; }

    public IDataTemplate? SeparatorTemplate { get; set; }

    protected override IDataTemplate SelectTemplateCore(object item)
    {
        return item is SeparatorItem ? SeparatorTemplate : ItemTemplate;
    }
}