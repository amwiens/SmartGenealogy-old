﻿using Avalonia;
using Avalonia.Styling;

using CommunityToolkit.Mvvm.ComponentModel;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;

using System.Collections.ObjectModel;

namespace SmartGenealogy.ViewModels.Settings;

public partial class SettingsPageViewModel : MainPageViewModelBase, ISettingsPageViewModel
{
    private readonly ISettingService _settingService;

    [ObservableProperty]
    private string _currentVersion = typeof(SmartGenealogy.Controls.PageHeaderControl).Assembly.GetName().Version?.ToString();

    [ObservableProperty]
    private ObservableCollection<ThemeVariant> _appThemes = new ObservableCollection<ThemeVariant> { ThemeVariant.Dark, ThemeVariant.Light };

    [ObservableProperty]
    private ThemeVariant _currentAppTheme = Application.Current.ActualThemeVariant;

    partial void OnCurrentAppThemeChanged(ThemeVariant? oldValue, ThemeVariant newValue)
    {
        if (oldValue != newValue && Application.Current.ActualThemeVariant != newValue)
        {
            Application.Current.RequestedThemeVariant = newValue;
            _settingService.Settings.CurrentTheme = newValue;
        }
    }

    public SettingsPageViewModel(ISettingService settingService)
    {
        _settingService = settingService;
    }
}