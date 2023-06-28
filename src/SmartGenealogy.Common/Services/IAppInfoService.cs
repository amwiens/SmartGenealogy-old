using System;

namespace SmartGenealogy.Common.Services;

public interface IAppInfoService
{
    public string GetAppNameLocalized();

    public Version GetAppVersion();
}