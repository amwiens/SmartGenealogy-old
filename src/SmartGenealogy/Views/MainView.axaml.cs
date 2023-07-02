﻿using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Styling;
using Avalonia.Threading;

using FluentAvalonia.Core;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Media.Animation;
using FluentAvalonia.UI.Navigation;
using FluentAvalonia.UI.Windowing;

using SmartGenealogy.Services;
using SmartGenealogy.ViewModels;

namespace SmartGenealogy.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        ClipboardService.Owner = TopLevel.GetTopLevel(this);
        // Simple check - all desktop versions of this app will have a window as the TopLevel Mobile
        // and WASM will have something else
        _isDesktop = TopLevel.GetTopLevel(this) is Window;
        var vm = new MainViewViewModel();
        DataContext = vm;
        FrameView.NavigationPageFactory = vm.NavigationFactory;
        NavigationService.Instance.SetFrame(FrameView);
        NavigationService.Instance.SetOverlayHost(OverlayHost);

        // On desktop, the window will call this during the splashscreen
        if (e.Root is AppWindow aw)
        {
            //(aw.SplashScreen as MainAppSplashScreen).InitApp += () =>
            //{
            InitializeNavigationPages();
            //};
        }
        else
        {
            InitializeNavigationPages();
        }

        FrameView.Navigated += OnFrameViewNavigated;
        NavView.ItemInvoked += OnNavigationViewItemInvoked;
        NavView.BackRequested += OnNavigationViewBackRequested;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();

        if (VisualRoot is AppWindow aw)
        {
            TitleBarHost.ColumnDefinitions[3].Width = new GridLength(aw.TitleBar.RightInset, GridUnitType.Pixel);
        }
    }

    public void InitializeNavigationPages()
    {
        var mainPages = new MainPageViewModelBase[]
        {
            new HomePageViewModel
            {
                NavHeader = "Home",
                IconKey = "HomeIcon"
            },
            new FilePageViewModel
            {
                NavHeader = "File",
                IconKey = "FileIcon"
            },
            new PeoplePageViewModel
            {
                NavHeader = "People",
                IconKey = "PeopleIcon"
            },
            new PlacesPageViewModel
            {
                NavHeader = "Places",
                IconKey = "PlacesIcon"
            },
            new SourcesPageViewModel
            {
                NavHeader = "Sources",
                IconKey = "SourcesIcon"
            },
            new MediaPageViewModel
            {
                NavHeader = "Media",
                IconKey = "MediaIcon"
            },
            new TasksPageViewModel
            {
                NavHeader = "Tasks",
                IconKey = "TasksIcon"
            },
            new AddressesPageViewModel
            {
                NavHeader = "Addresses",
                IconKey = "AddressesIcon"
            },
            new SearchPageViewModel
            {
                NavHeader = "Search",
                IconKey = "SearchIcon"
            },
            new PublishPageViewModel
            {
                NavHeader = "Publish",
                IconKey = "PublishIcon"
            },
            new ToolsPageViewModel
            {
                NavHeader = "Tools",
                IconKey = "ToolsIcon"
            },
            new SettingsPageViewModel
            {
                NavHeader = "Settings",
                IconKey = "SettingsIcon",
                ShowsInFooter = true
            }
        };

        var menuItems = new List<NavigationViewItemBase>(4);
        var footerItems = new List<NavigationViewItemBase>(2);

        bool inDesign = Design.IsDesignMode;

        Dispatcher.UIThread.Post(() =>
        {
            for (int i = 0; i < mainPages.Length; i++)
            {
                var pg = mainPages[i];
                var nvi = new NavigationViewItem
                {
                    Content = pg.NavHeader,
                    Tag = pg,
                    IconSource = (IconSource)this.FindResource(pg.IconKey)
                };

                //ToolTip.SetTip(nvi, pg.NavHeader);

                if (_isDesktop || OperatingSystem.IsBrowser())
                {
                    nvi.Classes.Add("SampleAppNav");
                }

                if (pg.ShowsInFooter)
                    footerItems.Add(nvi);
                else
                    menuItems.Add(nvi);

                if (!inDesign)
                {
                    (DataContext as MainViewViewModel).BuildSearchTerms(pg);
                }
            }

            NavView.MenuItemsSource = menuItems;
            NavView.FooterMenuItemsSource = footerItems;

            if (_isDesktop || OperatingSystem.IsBrowser())
            {
                NavView.Classes.Add("SampleAppNav");
            }
            else
            {
                NavView.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
            }

            FrameView.NavigateFromObject((NavView.MenuItemsSource.ElementAt(0) as Control).Tag);
        });
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        var pt = e.GetCurrentPoint(this);

        // Frame handles X1 -> BackRequested automatically, we can handle X2 here to enable forward navigation
        if (pt.Properties.PointerUpdateKind == PointerUpdateKind.XButton2Released)
        {
            if (FrameView.CanGoForward)
            {
                FrameView.GoForward();
                e.Handled = true;
            }
        }

        base.OnPointerReleased(e);
    }

    private void OnNavigationViewBackRequested(object sender, NavigationViewBackRequestedEventArgs e)
    {
        FrameView.GoBack();
    }

    private void OnNavigationViewItemInvoked(object sender, NavigationViewItemInvokedEventArgs e)
    {
        // Change the current selected item back to normal
        // SetNVIIcon(sender as NavigationViewItem, false);
        //if ((this.NavView.Content as Frame).BackStack.Count != 0 && (this.NavView.Content as Frame).BackStack[0].SourcePageType == e.InvokedItemContainer.GetType())
        //    return;

        if (e.InvokedItemContainer is NavigationViewItem nvi)
        {
            NavigationTransitionInfo info;

            // Keep the frame navigation when not using connected animation but suppress it
            // if we have a connected animation binding two pages
            //if (FrameView.Content is ControlsPageBase cpb &&
            //    ((cpb.TargetType != null && nvi.Tag is CoreControlsPageViewModel) ||
            //    (cpb.TargetType != null && nvi.Tag is FAControlsOverviewPageViewModel)))
            //{
            //    info = new SuppressNavigationTransitionInfo();
            //}
            //else
            //{
            info = e.RecommendedNavigationTransitionInfo;
            //}

            NavigationService.Instance.NavigateFromContext(nvi.Tag, info);
        }
    }

    private void OnFrameViewNavigated(object sender, NavigationEventArgs e)
    {
        var page = e.Content as Control;
        var dc = page.DataContext;

        MainPageViewModelBase mainPage = null;

        if (dc is MainPageViewModelBase mpvmb)
        {
            mainPage = mpvmb;
        }
        else if (dc is PageBaseViewModel pbvm)
        {
            mainPage = pbvm.Parent;
        }
        //else if (page is ControlsPageBase cpb)
        //{
        //    mainPage = cpb.CreationContext.Parent;
        //}

        foreach (NavigationViewItem nvi in NavView.MenuItemsSource)
        {
            if (nvi.Tag == mainPage)
            {
                NavView.SelectedItem = nvi;
                SetNVIIcon(nvi, true);
            }
            else
            {
                SetNVIIcon(nvi, false);
            }
        }

        foreach (NavigationViewItem nvi in NavView.FooterMenuItemsSource)
        {
            if (nvi.Tag == mainPage)
            {
                NavView.SelectedItem = nvi;
                SetNVIIcon(nvi, true);
            }
            else
            {
                SetNVIIcon(nvi, false);
            }
        }

        //if (FrameView.BackStackDepth > 0 && !NavView.IsBackButtonVisible)
        //{
        //    AnimateContentForBackButton(true);
        //}
        //else if (FrameView.BackStackDepth == 0 && NavView.IsBackButtonVisible)
        //{
        //    AnimateContentForBackButton(false);
        //}
    }

    private void SetNVIIcon(NavigationViewItem item, bool selected)
    {
        // Technically, yes you could set up binding and converters and whatnot to let the icon
        // change between filled and unfilled based on selection, but this is so much simpler

        if (item == null)
            return;

        var t = item.Tag;

        if (t is HomePageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "HomeIconFilled" : "HomeIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is FilePageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "FileIconFilled" : "FileIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is PeoplePageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "PeopleIconFilled" : "PeopleIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is PlacesPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "PlacesIconFilled" : "PlacesIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is SourcesPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "SourcesIconFilled" : "SourcesIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is MediaPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "MediaIconFilled" : "MediaIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is TasksPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "TasksIconFilled" : "TasksIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is AddressesPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "AddressesIconFilled" : "AddressesIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is SearchPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "SearchIconFilled" : "SearchIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is PublishPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "PublishIconFilled" : "PublishIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is ToolsPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "ToolsIconFilled" : "ToolsIcon", out var value) ?
                (IconSource)value : null;
        }
        else if (t is SettingsPageViewModel)
        {
            item.IconSource = this.TryFindResource(selected ? "SettingsIconFilled" : "SettingsIcon", out var value) ?
                (IconSource)value : null;
        }
    }

    private async void AnimateContentForBackButton(bool show)
    {
        if (!WindowIcon.IsVisible)
            return;

        if (show)
        {
            var ani = new Animation
            {
                Duration = TimeSpan.FromMilliseconds(250),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0d),
                        Setters =
                        {
                            new Setter(MarginProperty, new Thickness(12, 4, 12, 4))
                        }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1d),
                        KeySpline = new KeySpline(0,0,0,1),
                        Setters =
                        {
                            new Setter(MarginProperty, new Thickness(48,4,12,4))
                        }
                    }
                }
            };

            await ani.RunAsync(WindowIcon);

            NavView.IsBackButtonVisible = true;
        }
        else
        {
            NavView.IsBackButtonVisible = false;

            var ani = new Animation
            {
                Duration = TimeSpan.FromMilliseconds(250),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0d),
                        Setters =
                        {
                            new Setter(MarginProperty, new Thickness(48, 4, 12, 4))
                        }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1d),
                        KeySpline = new KeySpline(0,0,0,1),
                        Setters =
                        {
                            new Setter(MarginProperty, new Thickness(12,4,12,4))
                        }
                    }
                }
            };

            await ani.RunAsync(WindowIcon);
        }
    }

    private bool _isDesktop;
}