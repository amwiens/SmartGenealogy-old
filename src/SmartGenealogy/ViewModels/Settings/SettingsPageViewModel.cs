using Avalonia;
using Avalonia.Styling;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Serilog;

using SmartGenealogy.Contracts;
using SmartGenealogy.Contracts.ViewModels;
using SmartGenealogy.Models;

using System.Collections.ObjectModel;
using System.Globalization;

namespace SmartGenealogy.ViewModels.Settings;

public partial class SettingsPageViewModel : MainPageViewModelBase, ISettingsPageViewModel
{
    private readonly ILogger _logger;
    private readonly ILocalizationService _localizationService;
    private readonly ISettingService _settingService;

    [ObservableProperty]
    private string _currentVersion = typeof(Controls.PageHeaderControl).Assembly.GetName().Version?.ToString()!;


    [ObservableProperty]
    private ThemeVariant _currentAppTheme = Application.Current?.ActualThemeVariant!;

    [ObservableProperty]
    private int _currentLanguageIndex;

    [ObservableProperty]
    public ObservableCollection<ThemeVariant> _appThemes = new ObservableCollection<ThemeVariant> { ThemeVariant.Dark, ThemeVariant.Light };
    public List<Language> AvailableLanguages => _localizationService.AvailableLanguages;

    partial void OnCurrentAppThemeChanged(ThemeVariant? oldValue, ThemeVariant newValue)
    {
        if (oldValue != newValue && Application.Current?.ActualThemeVariant != newValue)
        {
            Application.Current.RequestedThemeVariant = newValue;
            _settingService.Settings.CurrentTheme = newValue.Key.ToString();
        }
    }

    partial void OnCurrentLanguageIndexChanged(int value)
    {
        if (CurrentLanguageIndex >= 0)
            _localizationService.SetLanguage(AvailableLanguages[CurrentLanguageIndex].Name!);
    }

    public SettingsPageViewModel(ILocalizationService localizationService,
        ISettingService settingService,
        ILogger logger)
    {
        _localizationService = localizationService;
        _logger = logger;
        _settingService = settingService;

        Initialize();
    }

    public void Initialize()
    {
        if (_settingService.Settings.LanguageCode is not null)
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(_settingService.Settings.LanguageCode);
        CurrentLanguageIndex = AvailableLanguages.FindIndex(x => x.Name == CultureInfo.CurrentUICulture.Name);
        CurrentAppTheme = AppThemes.Where(x => x.Key.ToString() == _settingService.Settings.CurrentTheme).SingleOrDefault()!;

        _logger.Information("Settings view model initialized");
    }

    [RelayCommand]
    private void SetLanguage() => _localizationService.SetLanguage(AvailableLanguages[CurrentLanguageIndex].Name!);
}