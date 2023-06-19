namespace SmartGenealogy.Models;

public class NavigationMenuItem
{
    public string Title { get; set; }
    public NavigationMenuIconItem FontImageIcon { get; set; }
    public Type TargetType { get; set; }
}