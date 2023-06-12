using MesengerApp.Services;
using MesengerApp.ViewModels;
using MesengerApp.Messager.Services;
using MesengerApp.Views;
using SimpleInjector;
using System.Windows;

namespace MesengerApp;
public partial class App : Application
{
    public static Container ServiceContainer { get; set; } = new Container();

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ConfigureContainer();

        StartWindow<LoginViewModel>();
    }

    private void ConfigureContainer()
    {
        ServiceContainer.RegisterSingleton<IMessenger, Messenger>();

        ServiceContainer.RegisterSingleton<MainViewModel>();
        ServiceContainer.RegisterSingleton<LoginViewModel>();
        ServiceContainer.RegisterSingleton<RegisterViewModel>();

        ServiceContainer.Verify();
    }

    private void StartWindow<T>() where T : ViewModelBase
    {
        var startView = new MainWindow();

        var startViewModel = ServiceContainer.GetInstance<MainViewModel>();
        startViewModel.ActiveViewModel = ServiceContainer.GetInstance<T>();
        startView.DataContext = startViewModel;

        startView.ShowDialog();
    }
}

