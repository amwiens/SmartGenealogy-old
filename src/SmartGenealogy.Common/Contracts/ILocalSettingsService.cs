﻿using System.Threading.Tasks;

namespace SmartGenealogy.Common.Contracts;

public interface ILocalSettingsService
{
    Task<T?> ReadSettingAsync<T>(string key);

    Task SaveSettingAsync<T>(string key, T value);
}