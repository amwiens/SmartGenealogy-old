﻿using Microsoft.Extensions.Localization;

namespace SmartGenealogy.Extensions;

[ContentProperty(nameof(Key))]
public class LocalizeExtension : IMarkupExtension
{
    private IStringLocalizer<AppTranslations> _localizer;

    public string Key { get; set; } = string.Empty;

    public LocalizeExtension()
    {
        _localizer = ServiceHelper.GetService<IStringLocalizer<AppTranslations>>();
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        string localizedText = _localizer[Key];
        return localizedText;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}