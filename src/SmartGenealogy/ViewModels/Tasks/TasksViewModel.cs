using Serilog;

using SmartGenealogy.Contracts.ViewModels;

namespace SmartGenealogy.ViewModels.Tasks;

public partial class TasksViewModel : MainPageViewModelBase, ITasksViewModel
{
    private readonly ILogger _logger;

    public TasksViewModel(ILogger logger)
    {
        _logger = logger;

        _logger.Information("Tasks view model initialized");
    }
}