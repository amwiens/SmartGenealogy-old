using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Media;

public partial class MediaViewModel : MainPageViewModelBase, IMediaViewModel
{
    private readonly ILogger _logger;

    public MediaViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Media view model initialized");
    }
}