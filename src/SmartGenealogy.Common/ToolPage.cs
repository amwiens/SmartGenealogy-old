using Microsoft.UI.Xaml.Controls;

namespace SmartGenealogy.Common;

public abstract class ToolPage : Page
{
    public abstract string ShortName { get; }
}