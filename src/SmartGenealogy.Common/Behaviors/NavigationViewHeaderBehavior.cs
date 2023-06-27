using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGenealogy.Common.Behaviors;

public class NavigationViewHeaderBehavior : Behavior<NavigationView>
{
    private static NavigationViewHeaderBehavior? _current;

    private Page? _currentPage;

    public DataTemplate? DefaultHeaderTemplate
    {
        get; set;
    }

    public object DefaultHeader
    {
        get => GetValue(DefaultHeaderProperty);
        set => SetValue(DefaultHeaderProperty, value);
    }


}