namespace SmartGenealogy.ViewModels;

public partial class HomePageViewModel : BaseViewModel
{
    private List<HomeBanner> _bannerItems;
    private int _position;

    public HomePageViewModel()
    {
        LoadBannerCollection();
        WeakReferenceMessenger.Default.Register<CultureChangeMessage>(this);

        CarouselRotateService();
    }

    /// <summary>
    /// On received culture changed message, reload banner items
    /// </summary>
    /// <param name="message"></param>
    public override void Receive(CultureChangeMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LoadBannerCollection();
        });
    }

    [RelayCommand]
    public async void NavigateToPeopleAsync()
    {
        //await Navigation.
    }

    public void LoadBannerCollection()
    {
        BannerItems = new List<HomeBanner>
        {
            new HomeBanner
            {
                Title = LocalizationResourceManager.Translate("StringBannerEcommerce"),
                Icon = IonIcons.Bag,
                BackgroundColor = Color.FromArgb("#CD195E"),
                BackgroundGradientStart = Color.FromArgb("#38b8f2"),
                BackgroundGradientEnd = Color.FromArgb("#843cf7"),
                Body = LocalizationResourceManager.Translate("StringBannerEcommerceDescription"),
                BackgroundImage = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ecommerce.jpg"
            },
            new HomeBanner
            {
                Title = LocalizationResourceManager.Translate("StringBannerNews"),
                Icon = IonIcons.Network,
                BackgroundColor = Color.FromArgb("#833ab4"),
                BackgroundGradientStart = Color.FromArgb("#ee0979"),
                BackgroundGradientEnd = Color.FromArgb("#ff6a00"),
                Body = LocalizationResourceManager.Translate("StringBannerNewsDescription"),
                BackgroundImage = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/news-magazine.jpg"
            },
            new HomeBanner
            {
                Title = LocalizationResourceManager.Translate("StringBannerPropertyListing"),
                Icon = IonIcons.Home,
                BackgroundColor = Color.FromArgb("#1DA1F2"),
                BackgroundGradientStart = Color.FromArgb("#004b91"),
                BackgroundGradientEnd = Color.FromArgb("#78cc37"),
                Body = LocalizationResourceManager.Translate("StringBannerPropertyListingDescription"),
                BackgroundImage = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/property-listing.jpg"
            },
            new HomeBanner
            {
                Title = LocalizationResourceManager.Translate("StringBannerSocials"),
                Icon = IonIcons.Chatboxes,
                BackgroundColor = Color.FromArgb("#BD3434"),
                BackgroundGradientStart = Color.FromArgb("#9B3cb7"),
                BackgroundGradientEnd = Color.FromArgb("#FF396f"),
                Body = LocalizationResourceManager.Translate("StringBannerSocialsDescription"),
                BackgroundImage = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/socials.jpg"
            },
            new HomeBanner
            {
                Title = LocalizationResourceManager.Translate("StringBannerArticles"),
                Icon = IonIcons.Filing,
                BackgroundColor = Color.FromArgb("#319E3A"),
                BackgroundGradientStart = Color.FromArgb("#ff9632"),
                BackgroundGradientEnd = Color.FromArgb("#e55313"),
                Body = LocalizationResourceManager.Translate("StringBannerArticlesDescription"),
                BackgroundImage = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/articles.jpg"
            }
        };

        if (BannerItems != null && BannerItems.Any())
        {
            CarouselRotateService();
        }
    }

    private async void CarouselRotateService()
    {
        using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(7)))
        {
            while (await timer.WaitForNextTickAsync())
            {
                Position = (Position + 1) % BannerItems.Count;
            }
        }
    }

    public int Position
    {
        get { return _position; }
        set
        {
            _position = value;
            OnPropertyChanged("Position");
        }
    }

    public List<HomeBanner> BannerItems
    {
        get { return _bannerItems; }
        set { SetProperty(ref _bannerItems, value); }
    }
}