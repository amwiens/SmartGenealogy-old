namespace SmartGenealogy.Views.Popups;

public partial class SelectItemDialogPopup : Popup
{
    private object _InitialValue { get; }

    public object ReturnValue
    {
        get { return (object)GetValue(ReturnValueProperty); }
        set { SetValue(ReturnValueProperty, value); }
    }

    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly BindableProperty ReturnValueProperty = BindableProperty.Create(nameof(ReturnValue), typeof(object), typeof(SelectItemDialogPopup));
    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(SelectItemDialogPopup));

    public ICommand CloseDialogCommand { get; set; }
    public ICommand CancelDialogCommand { get; set; }
    public ICommand ResetReturnValueCommand { get; set; }

    public SelectItemDialogPopup(object InitialValue, IEnumerable ItemsSource)
    {
        CloseDialogCommand = new Command(() => Close(ReturnValue));
        CancelDialogCommand = new Command(CancelDialog);
        ResetReturnValueCommand = new Command(ResetReturnValue);

        InitializeComponent();

        _InitialValue = InitialValue;
        this.ItemsSource = ItemsSource;

        ResetReturnValue();
        ResultWhenUserTapsOutsideOfPopup = _InitialValue;
    }

    public void CancelDialog()
    {
        Close(_InitialValue);
    }

    public void ResetReturnValue()
    {
        ReturnValue = _InitialValue;
    }
}