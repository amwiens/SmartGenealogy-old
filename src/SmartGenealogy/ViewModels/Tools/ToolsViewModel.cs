using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Tools;

public partial class ToolsViewModel : MainPageViewModelBase, IToolsViewModel
{
    private readonly ILogger _logger;

    public ToolsViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Tools;

        _logger.Information("Tools view model initialized");
    }
}