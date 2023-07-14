using SmartGenealogy.Models;

namespace SmartGenealogy.Contracts;

public interface ILocalizationService
{
    string this[string resourceKey] { get; }
    List<Language> AvailableLanguages { get; }
    void SetLanguage(string language);
}