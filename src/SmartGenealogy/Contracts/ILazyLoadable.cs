namespace SmartGenealogy.Contracts;

public interface ILazyLoadable
{
    bool IsVisible { get; set; }
    bool IsLoaded { get; set; }
    Task LoadAsync();
    Task UpdateAsync();
    Task<bool> BackAsync();
}