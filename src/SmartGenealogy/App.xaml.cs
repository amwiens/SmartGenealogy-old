namespace SmartGenealogy;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        #region Handlers

        // Borderless entry
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                //handler.PlatformView.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform();
                //handler.PlatformView.Layer.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToCGColor();
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                handler.PlatformView.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                handler.PlatformView.UnderlineThickness = new Windows.UI.Xaml.Thickness(0);
#endif
            }
        });

        // Borderless editor
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEditor), (handler, view) =>
        {
            if (view is BorderlessEditor)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                handler.PlatformView.BorderThickness = new Windows.UI.Xaml.Thickness(0);
#endif
            }
        });

        #endregion Handlers

        if (AppSettings.AppSettings.IsFirstLaunching)
        {
            AppSettings.AppSettings.IsFirstLaunching = true; // Set to 'false' in production
            MainPage = new DesktopShell();
        }
        else
#if WINDOWS || MACCATALYST
            MainPage = new DesktopShell();
#else
            MainPage = new MobileShell();
#endif
    }
}