using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Tools;

public partial class ToolsViewModel : MainPageViewModelBase, IToolsViewModel
{
    private readonly ILogger _logger;

    public ToolsViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Tools view model initialized");
    }
}