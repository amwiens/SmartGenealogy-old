namespace SmartGenealogy.ViewModels;

public partial class ViewModelBase : BindableObject, INotifyPropertyChanged
{
    public ICommand BackCommand => new Command(OnBack);

    private void OnBack()
    {
        NavigationService.Instance.NavigateBackAsync();
    }

    public virtual Task InitializeAsync(object navigationData)
    {
        return Task.FromResult(false);
    }

    private bool _isBusy = true;

    public bool IsBusy
    {
        get { return _isBusy; }
        set { SetProperty(ref _isBusy, value); }
    }

    private string _loadingText = string.Empty;

    public string LoadingText
    {
        get { return _loadingText; }
        set { SetProperty(ref _loadingText, value); }
    }

    private bool _dataLoaded = false;

    public bool DataLoaded
    {
        get { return _dataLoaded; }
        set { SetProperty(ref _dataLoaded, value); }
    }

    private bool _isErrorState = false;

    public bool IsErrorState
    {
        get { return _isErrorState; }
        set { SetProperty(ref _isErrorState, value); }
    }

    private string _errorMessage = string.Empty;

    public string ErrorMessage
    {
        get { return _errorMessage; }
        set { SetProperty(ref _errorMessage, value); }
    }

    private string _errorImage = string.Empty;

    public string ErrorImage
    {
        get { return _errorImage; }
        set { SetProperty(ref _errorImage, value); }
    }

    // Called on Page Appearing
    public virtual async void OnNavigatedTo(object parameters) =>
        await Task.CompletedTask;

    // Set Loading Indicators for Page
    protected void SetDataLoadingIndicators(bool isStarting = true)
    {
        if (isStarting)
        {
            IsBusy = true;
            DataLoaded = false;
            IsErrorState = false;
            ErrorMessage = string.Empty;
            ErrorImage = string.Empty;
        }
        else
        {
            LoadingText = "";
            IsBusy = false;
        }
    }

    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion INotifyPropertyChanged
}