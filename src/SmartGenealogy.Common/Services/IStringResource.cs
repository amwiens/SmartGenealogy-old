namespace SmartGenealogy.Common.Services;

public interface IStringResource
{
    public string GetLocalized(string key, params object[] args);
}