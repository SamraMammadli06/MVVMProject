using MesengerApp.Tools;
using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using System;
using System.Windows;

namespace MesengerApp.ViewModels;
public class LoginViewModel : ViewModelBase
{
    private readonly IMessenger messenger;
    public LoginViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
    }

    #region Commands

    private MyCommand? registerComand;

    public MyCommand RegisterComand
    {
        get => this.registerComand ??= new MyCommand(
            action: () => RegisterUser(),
            predicate: () => true);
        set => base.PropertyChange(out this.registerComand, value);
    }
    #endregion

    #region Methods
    void RegisterUser()
    {
        try
        {
            //var user = this.usersRepository.Login(this.Login, this.Password);

            //this.Login = string.Empty;
            //this.Password = string.Empty;

            //this.messenger.Send(new SendLoginedUserMessage(user) { WhenLogined = DateTime.Now });
            this.messenger.Send(new NavigationMessage(typeof(RegisterViewModel)));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                messageBoxText: ex.Message,
                caption: "User SignUp Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);
        }
    }
    #endregion
}

