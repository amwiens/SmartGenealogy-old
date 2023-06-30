using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ReactiveUI;

using SmartGenealogy.Helpers;
using SmartGenealogy.ViewModels;
using SmartGenealogy.Views;

namespace SmartGenealogy;

public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation. Without this line you will get
        // duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        // Create the AutoSuspendHelper.
        var suspension = new AutoSuspendHelper(ApplicationLifetime);
        RxApp.SuspensionHost.CreateNewAppState = () => new MainWindowViewModel();
        RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
        suspension.OnFrameworkInitializationCompleted();

        // Load the saved view model state.
        var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();
        new MainWindow { DataContext = state }.Show();

        //if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        //{
        //    desktop.MainWindow = new MainWindow
        //    {
        //        DataContext = new MainWindowViewModel()
        //    };
        //}
        //else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        //{
        //    singleViewPlatform.MainView = new MainView
        //    {
        //        DataContext = new MainViewViewModel()
        //    };
        //}

        base.OnFrameworkInitializationCompleted();
    }
}