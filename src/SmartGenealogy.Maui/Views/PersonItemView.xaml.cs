namespace SmartGenealogy.Maui.Views;

public partial class PersonItemView
{
	public PersonItemView()
	{
		InitializeComponent();
	}

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is not PersonViewModel vm)
        {
            return;
        }

        //vm.InitializeCommand.Execute(null);
    }
}