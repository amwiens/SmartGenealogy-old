using Serilog;

using SmartGenealogy.Contracts.ViewModels;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.ViewModels.Tasks;

public partial class TasksViewModel : MainPageViewModelBase, ITasksViewModel
{
    private readonly ILogger _logger;

    public TasksViewModel(ILogger logger)
    {
        _logger = logger;

        NavHeader = XAML_Navigation_Tasks;

        _logger.Information("Tasks view model initialized");
    }
}