using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.ApplicationModel.AppExtensions;

namespace SmartGenealogy.Common.Services;

public interface IPluginService
{
    Task<IEnumerable<IPluginWrapper>> GetInstalledPluginsAsync(bool includeDisabledPlugins = false);

    Task<IEnumerable<IPluginWrapper>> GetInstalledPluginsAsync(ProviderType providerType, bool includeDisabledPlugins = false);

    Task<IEnumerable<IPluginWrapper>> StartAllPluginsAsync();

    Task SignalStopPluginsAsync();

    Task<IEnumerable<AppExtension>> GetInstalledAppExtensionsAsync();

    public event EventHandler OnPluginsChanged;
}