﻿using CommunityToolkit.Mvvm.Messaging;

using SmartGenealogy.Maui.Messaging;

namespace SmartGenealogy.Maui.Helpers;

public static class TheTheme
{
    public static void SetTheme()
    {
        switch (Settings.Theme)
        {
            default:
            case AppTheme.Light:
                App.Current.UserAppTheme = AppTheme.Light;
                break;
            case AppTheme.Dark:
                App.Current.UserAppTheme= AppTheme.Dark;
                break;
        }

        WeakReferenceMessenger.Default.Send<ChangeThemeNotification>();
    }
}