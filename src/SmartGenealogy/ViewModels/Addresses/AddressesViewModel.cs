using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Addresses;

public partial class AddressesViewModel : MainPageViewModelBase, IAddressesViewModel
{
    private readonly ILogger _logger;

    public AddressesViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Addresses view model initialized");
    }
}