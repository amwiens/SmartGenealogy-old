using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Sources;

public partial class SourcesViewModel : MainPageViewModelBase, ISourcesViewModel
{
    private readonly ILogger _logger;

    public SourcesViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Sources;

        _logger.Information("Sources view model initialized");
    }
}