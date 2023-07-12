using FluentAvalonia.UI.Controls;

namespace SmartGenealogy.Models;

public class NavigationItem : NavigationItemBase
{
    public string? Name { get; set; }

    public string? ToolTip { get; set; }

    public Symbol Icon { get; set; }
}