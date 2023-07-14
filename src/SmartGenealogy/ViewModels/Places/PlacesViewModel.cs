using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Places;

public partial class PlacesViewModel : MainPageViewModelBase, IPlacesViewModel
{
    private readonly ILogger _logger;

    public PlacesViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Places;

        _logger.Information("Places view model initialized");
    }
}