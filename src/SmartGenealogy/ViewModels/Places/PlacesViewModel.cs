using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Places;

public partial class PlacesViewModel : MainPageViewModelBase, IPlacesViewModel
{
    private readonly ILogger _logger;

    public PlacesViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Places view model initialized");
    }
}