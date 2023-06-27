using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGenealogy.Settings.ViewModels;

public class AccountsViewModel : ObservableObject
{
    public ObservableCollection<AccountsProviderViewModel> AccountsProviders { get; } = new ();

    public AccountsViewModel()
    {
        var devIdProviders = Task.Run(async () => await Application.Current.GetService<IAccountsService>().GetDevIdProviders()).Result;
        devIdProviders.ToList().ForEach((devIdProvider) =>
        {
            AccountsProviders.Add(new AccountsProviderViewModel(devIdProvider));
        });
    }
}