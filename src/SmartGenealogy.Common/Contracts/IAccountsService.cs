using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGenealogy.Common.Contracts.Services;

public interface IAccountsService
{
    Task InitializeAsync();

    Task<IReadOnlyList<IDeveloperIdProvider>> GetDevIdProviders();

    IReadOnlyList<IDeveloperId> GetDeveloperIds(IDeveloperIdProvider iDevIdProvider);

    IReadOnlyList<IDeveloperId> GetDeveloperIds(IPlugin plugin);
}