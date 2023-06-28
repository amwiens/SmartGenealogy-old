using Microsoft.UI.Xaml;

using System;
using System.Threading.Tasks;

namespace SmartGenealogy.Common.Services;

public interface IThemeSelectorService
{
    public event EventHandler<ElementTheme> ThemeChanged;

    ElementTheme Theme
    {
        get;
    }

    Task InitializeAsync();

    Task SetThemeAsync(ElementTheme theme);

    void SetRequestedTheme();

    /// <summary>
    /// Checks if the <see cref="Theme"/> value resolves to dark
    /// </summary>
    /// <returns>True if the current theme is dark</returns>
    bool IsDarkTheme();
}