using MesengerApp.Services;
using MesengerApp.Messager.Messages;

namespace MesengerApp.ViewModels;
public class MainViewModel :ViewModelBase
{
    private ViewModelBase? activeViewModel;
    private readonly IMessenger messenger;

    public ViewModelBase? ActiveViewModel
    {
        get { return activeViewModel; }
        set { this.PropertyChange(out activeViewModel, value); }
    }

    public MainViewModel(IMessenger messenger)
    {
        this.messenger = messenger;

        this.messenger.Subscribe<NavigationMessage>((message) =>
        {
            if (message is NavigationMessage navigationMessage)
            {
                var serviceObj = App.ServiceContainer.GetInstance(navigationMessage.NavigateTo);

                if (serviceObj is ViewModelBase vm)
                    this.ActiveViewModel = vm;
            }
        });
    }
}

