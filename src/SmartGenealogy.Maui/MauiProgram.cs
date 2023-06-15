using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using SkiaSharp.Views.Maui.Controls.Hosting;

//using Syncfusion.Maui.Core.Hosting;

using UraniumUI;

namespace SmartGenealogy.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .ConfigureEssentials()
                .ConfigureServices()
                .ConfigurePages()
                .ConfigureViewModels()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Segoe-Ui-Bold.ttf", "SegoeUiBold");
                    fonts.AddFont("Segoe-Ui-Regular.ttf", "SegoeUiRegular");
                    fonts.AddFont("Segoe-Ui-Semibold.ttf", "SegoeUiSemibold");
                    fonts.AddFont("Segoe-Ui-Semilight.ttf", "SegoeUiSemilight");
                })
                .UseUraniumUI()
                .UseUraniumUIMaterial();

#if DEBUG
		builder.Logging.AddDebug();
#endif
            //builder.ConfigureSyncfusionCore();

            return builder.Build();
        }
    }
}