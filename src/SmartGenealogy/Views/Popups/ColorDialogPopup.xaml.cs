namespace SmartGenealogy.Views.Popups;

public partial class ColorDialogPopup : Popup
{
    public Color InitialSelectedColor { get; }

    public Color SelectedColor
    {
        get { return (Color)GetValue(SelectedColorProperty); }
        set { SetValue(SelectedColorProperty, value); }
    }

    public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(ColorDialogPopup));

    public ICommand CancelDialogCommand { get; }
    public ICommand DismissDialogCommand { get; }
    public ICommand ResetReturnValueCommand { get; }

    public ColorDialogPopup()
        : this(new Color())
    {
    }

    public ColorDialogPopup(Color InitialSelectedColor)
    {
        CancelDialogCommand = new Command(CancelDialog);
        DismissDialogCommand = new Command(DismissDialog);
        ResetReturnValueCommand = new Command(ResetReturnValue);

        InitializeComponent();

        this.InitialSelectedColor = InitialSelectedColor;
        ResultWhenUserTapsOutsideOfPopup = InitialSelectedColor;
        SelectedColor = InitialSelectedColor;
    }

    public void CancelDialog()
    {
        Close(InitialSelectedColor);
    }

    public void DismissDialog()
    {
        Close(SelectedColor);
    }

    public void ResetReturnValue()
    {
        SelectedColor = InitialSelectedColor;
    }
}