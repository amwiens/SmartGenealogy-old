using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Styling;

using FluentAvalonia.Styling;
using FluentAvalonia.UI.Media;
using FluentAvalonia.UI.Windowing;

using SmartGenealogy.Extensions;
using SmartGenealogy.Models;

namespace SmartGenealogy.Views;

public partial class MainWindow : AppWindow
{
    private Setting _setting;

    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);

        _setting = SettingExtensions.SettingService.Settings;

        this.Closing += (sender, e) => SaveWindowSizeAndPosition();
        this.Loaded += MainWindow_Loaded;

#if DEBUG
        this.AttachDevTools();
#endif

        //SplashScreen = new MainAppSplashScreen(this);
        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;

        Application.Current.ActualThemeVariantChanged += OnActualThemeVariantChanged;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        if (File.Exists("Settings.json"))
        {
            this.Width = _setting.Width - 1;
            this.Position = new PixelPoint(_setting.X, _setting.Y);
            this.Height = _setting.Height;
            this.Width = _setting.Width;
            this.WindowState = _setting.IsMaximized ? WindowState.Maximized : WindowState.Normal;
            Application.Current.RequestedThemeVariant = _setting.CurrentTheme;
        }
        else
        {
            var screen = Screens.Primary;
            var workingArea = screen.WorkingArea;

            double dpiScaling = screen.PixelDensity;
            this.Width = 1300 * dpiScaling;
            this.Height = 840 * dpiScaling;

            this.Position = new PixelPoint(5, 0);
        }
    }

    private void OnActualThemeVariantChanged(object? sender, EventArgs e)
    {
        if (IsWindows11)
        {
            if (ActualThemeVariant != FluentAvaloniaTheme.HighContrastTheme)
            {
                TryEnableMicaEffect();
            }
            else
            {
                ClearValue(BackgroundProperty);
                ClearValue(TransparencyBackgroundFallbackProperty);
            }
        }
    }

    public void SaveWindowSizeAndPosition()
    {
        _setting.IsMaximized = this.WindowState == WindowState.Maximized;
        this.WindowState = WindowState.Normal;
        _setting.Width = this.Width;
        _setting.Height = this.Height;
        _setting.X = this.Position.X;
        _setting.Y = this.Position.Y;
    }

    private void TryEnableMicaEffect()
    {
        //return;
        // TransparencyBackgroundFallback = Brushes.Transparent; TransparencyLevelHint = WindowTransparencyLevel.Mica;

        // The background colors for the Mica brush are still based around
        // SolidBackgroundFillColorBase resource BUT since we can't control the actual Mica brush
        // color, we have to use the window background to create the same effect. However, we can't
        // use SolidBackgroundFillColorBase directly since its opaque, and if we set the opacity the
        // color become lighter than we want. So we take the normal color, darken it and apply the
        // opacity until we get the roughly the correct color NOTE that the effect still doesn't
        // look right, but it suffices. Ideally we need access to the Mica CompositionBrush to
        // properly change the color but I don't know if we can do that or not
        if (ActualThemeVariant == ThemeVariant.Dark)
        {
            var color = this.TryFindResource("SolidBackgroundFillColorBase",
                ThemeVariant.Dark, out var value) ? (Color2)(Color)value : new Color2(32, 32, 32);

            color = color.LightenPercent(-0.8f);

            Background = new ImmutableSolidColorBrush(color, 0.9);
        }
        else if (ActualThemeVariant == ThemeVariant.Light)
        {
            // Similar effect here
            var color = this.TryFindResource("SolidBackgroundFillColorBase",
                ThemeVariant.Light, out var value) ? (Color2)(Color)value : new Color2(243, 243, 243);

            color = color.LightenPercent(0.5f);

            Background = new ImmutableSolidColorBrush(color, 0.9);
        }
    }
}