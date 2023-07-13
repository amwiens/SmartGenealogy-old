﻿using CommunityToolkit.Mvvm.ComponentModel;

using FluentAvalonia.UI.Controls;

using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Models;

public partial class NavigationItem : NavigationItemBase
{
    public readonly string? Name;
    
    [ObservableProperty]
    private string? _displayName;

    public ViewModelBase ViewModel { get; set; }

    public Symbol Icon { get; set; }

    public NavigationItem(ViewModelBase viewModel, string displayName, string name, Symbol icon)
    {
        ViewModel = viewModel;
        DisplayName = displayName;
        Name = name;
        Icon = icon;
    }
}