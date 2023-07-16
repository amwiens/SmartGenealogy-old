using SmartGenealogy.Models;

namespace SmartGenealogy.Contracts;

public interface INavigationService
{
    LazyLoadableList Items { get; set; }
    bool CanGoBack { get; set; }
    Task NavigateAsync(ILazyLoadable lazyLoadable);
    Task Clear();
    Task<bool> BackAsync();
}