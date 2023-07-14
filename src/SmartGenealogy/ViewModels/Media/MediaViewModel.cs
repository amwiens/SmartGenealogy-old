using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Media;

public partial class MediaViewModel : MainPageViewModelBase, IMediaViewModel
{
    private readonly ILogger _logger;

    public MediaViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Media;

        _logger.Information("Media view model initialized");
    }
}