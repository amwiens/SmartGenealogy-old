﻿using CommunityToolkit.Mvvm.ComponentModel;

using SmartGenealogy.Contracts;
using SmartGenealogy.Models;

namespace SmartGenealogy.ViewModels;

public partial class NavigationViewModel : ViewModelBase, INavigationService
{
    [ObservableProperty]
    private LazyLoadableList _items;

    [ObservableProperty]
    private bool _canGoBack;

    public NavigationViewModel()
    {
        _items = new LazyLoadableList();
    }

    public async Task NavigateAsync(ILazyLoadable lazyLoadable)
    {
        if (Items.Count >= 1)
        {
            var currentLazyLoadable = Items[^1];
            currentLazyLoadable.IsVisible = false;
        }

        Items.Add(lazyLoadable);
        lazyLoadable.IsVisible = true;

        CanGoBack = Items.Count > 1;

        await lazyLoadable.LoadAsync();
    }

    public async Task Clear()
    {
        Items.Clear();

        CanGoBack = false;

        await Task.Yield();
    }

    public async Task<bool> BackAsync()
    {
        if (Items.Count > 1)
        {
            var currentLazyLoadable = Items[^1];
            currentLazyLoadable.IsVisible = false;
            Items.Remove(currentLazyLoadable);

            if (Items.Count >= 1)
            {
                var nextLazyLoadable = Items[^1];
                nextLazyLoadable.IsVisible = true;
            }

            CanGoBack |= Items.Count > 1;

            return await Task.FromResult(true);
        }

        return await Task.FromResult(false);
    }
}