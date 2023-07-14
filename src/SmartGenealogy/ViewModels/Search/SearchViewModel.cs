using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Search;

public partial class SearchViewModel : MainPageViewModelBase, ISearchViewModel
{
    private readonly ILogger _logger;

    public SearchViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Search view model initialized");
    }
}