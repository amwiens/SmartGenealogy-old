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

using System.Text.Json;

namespace SmartGenealogy.Views;

public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        //InitializeComponent();
        AvaloniaXamlLoader.Load(this);

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
        var settings = await LoadAppSettingsAsync();

        if (File.Exists(Path.Combine(settings.AppDataPath, "settings.json")))
        {
            this.Width = settings.Width - 1;
            this.Position = new PixelPoint(settings.X, settings.Y);
            this.Height = settings.Height;
            this.Width = settings.Width;
            this.WindowState = settings.IsMaximized ? WindowState.Maximized : WindowState.Normal;
            Application.Current.RequestedThemeVariant = settings.CurrentTheme;
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

    private async Task<AppSettings.AppSettings> LoadAppSettingsAsync()
    {
        var settings = AppSettings.AppSettings.Instance;

        settings = new AppSettings.AppSettings();

        if (File.Exists(Path.Combine(settings.AppDataPath, "settings.json")))
        {
            try
            {
                var options = new JsonSerializerOptions();
                //options.Converters.Add(new DataGridLengthConverter());

                var jsonString = File.ReadAllText(Path.Combine(settings.AppDataPath, "settings.json"));
                settings = JsonSerializer.Deserialize<AppSettings.AppSettings>(jsonString, options);
            }
            catch (Exception)
            {

            }
        }

        return settings;
    }

    public void SaveWindowSizeAndPosition()
    {
        var settings = AppSettings.AppSettings.Instance;
        settings.IsMaximized = this.WindowState == WindowState.Maximized;
        this.WindowState = WindowState.Normal;
        settings.Width = this.Width;
        settings.Height = this.Height;
        settings.X = this.Position.X;
        settings.Y = this.Position.Y;

        SaveAppSettings(settings);
    }

    private void SaveAppSettings(AppSettings.AppSettings appSettings)
    {
        var jsonString = JsonSerializer.Serialize(appSettings);
        File.WriteAllText(Path.Combine(appSettings.AppDataPath, "settings.json"), jsonString);
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