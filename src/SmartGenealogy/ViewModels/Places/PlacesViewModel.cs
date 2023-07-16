using CommunityToolkit.Mvvm.ComponentModel;

using Serilog;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Places;

public partial class PlacesViewModel : MainPageViewModelBase, IPlacesViewModel, ILazyLoadable
{
    private readonly ILogger _logger;

    [ObservableProperty]
    private bool _isVisible;

    [ObservableProperty]
    private INavigationService? _navigation;

    public PlacesViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Places;

        _logger.Information("Places view model initialized");
    }
}