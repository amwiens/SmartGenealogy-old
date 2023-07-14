using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Search;

public partial class SearchViewModel : MainPageViewModelBase, ISearchViewModel
{
    private readonly ILogger _logger;

    public SearchViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Search;

        _logger.Information("Search view model initialized");
    }
}