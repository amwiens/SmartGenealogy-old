using CommunityToolkit.Mvvm.ComponentModel;

using SmartGenealogy.Logging;
using SmartGenealogy.Settings.Models;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SmartGenealogy.Settings.ViewModels;

public partial class AccountsProviderViewModel : ObservableObject
{
    public IDeveloperIdProvider DeveloperIdProvider { get; }

    public string ProviderName => DeveloperIdProvider.GetName();

    public ObservableCollection<Account> LoggedInAccounts { get; } = new();

    public AccountsProviderViewModel(IDeveloperIdProvider devIdProvider)
    {
        DeveloperIdProvider = devIdProvider;
        RefreshLoggedInAccounts();
    }

    public void RefreshLoggedInAccounts()
    {
        LoggedInAccounts.Clear();
        DeveloperIdProvider.GetLoggedInDeveloperIds().ToList().ForEach((devId) =>
        {
            LoggedInAccounts.Add(new Account(this, devId));
        });
    }

    public void RemoveAccount(string loginId)
    {
        var accountToRemove = LoggedInAccounts.FirstOrDefault(x => x.LoginId == loginId);
        if (accountToRemove != null)
        {
            try
            {
                DeveloperIdProvider.LogoutDeveloperId(accountToRemove.GetDevId());
            }
            catch (Exception ex)
            {
                GlobalLog.Logger?.ReportError($"RemoveAccount() failed - developerId: {loginId}.", ex);
                throw;
            }
        }

        RefreshLoggedInAccounts();
    }
}