using System.Globalization;

namespace SmartGenealogy.Models;

public class Language
{
    public string? Name { get; set; }

    private string? DisplayName { get; set; }

    public string FullName => $"{Name} - {DisplayName}";

    public Language(string name, string displayName)
    {
        Name = name;
        DisplayName = displayName;
    }

    public Language(CultureInfo cultureInfo)
    {
        Name = cultureInfo.Name;
        DisplayName = cultureInfo.DisplayName;
    }
}