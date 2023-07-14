using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Sources;

public partial class SourcesViewModel : MainPageViewModelBase, ISourcesViewModel
{
    private readonly ILogger _logger;

    public SourcesViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Sources view model initialized");
    }
}