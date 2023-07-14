using SmartGenealogy.Models;

namespace SmartGenealogy.Contracts;

public interface ISettingService
{
    public Setting Settings { get; }

    Task InitializeSettings();

    Task OnChoosePath();
}