using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartGenealogy.Maui.MVVM;

public class BaseViewModel : ObservableRecipient
{

    protected BaseViewModel()
    {

    }

    //[RelayCommand]
    //protected virtual Task BackAsync() => AppNavigator.GoBackAsync();
}