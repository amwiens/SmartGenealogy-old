using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace SmartGenealogy.Maui.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Search()
    {
        //IEnumerable<>
    }

    [RelayCommand]
    async Task CreateToast()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        await Toast.Make("Test the toast feature!", ToastDuration.Long, 16).Show(cancellationTokenSource.Token);
    }
}