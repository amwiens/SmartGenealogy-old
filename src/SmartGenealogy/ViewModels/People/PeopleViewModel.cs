using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.People;

public partial class PeopleViewModel : MainPageViewModelBase, IPeopleViewModel
{
    private readonly ILogger _logger;

    public PeopleViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_People;

        _logger.Information("People view model initialized");
    }
}