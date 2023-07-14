using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Publish;

public partial class PublishViewModel : MainPageViewModelBase, IPublishViewModel
{
    private readonly ILogger _logger;

    public PublishViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Publish;

        _logger.Information("Publish view model initialized");
    }
}