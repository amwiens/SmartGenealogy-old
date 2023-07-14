using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Publish;

public partial class PublishViewModel : MainPageViewModelBase, IPublishViewModel
{
    private readonly ILogger _logger;

    public PublishViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Publish view model initialized");
    }
}