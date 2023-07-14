using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;


namespace SmartGenealogy.ViewModels.Addresses;

public partial class AddressesViewModel : MainPageViewModelBase, IAddressesViewModel
{
    private readonly ILogger _logger;

    public AddressesViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Addresses;

        _logger.Information("Addresses view model initialized");
    }
}