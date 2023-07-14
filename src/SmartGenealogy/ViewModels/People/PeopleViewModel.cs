using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.People;

public partial class PeopleViewModel : MainPageViewModelBase, IPeopleViewModel
{
    private readonly ILogger _logger;

    public PeopleViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("People view model initialized");
    }
}