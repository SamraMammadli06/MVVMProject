using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;
using MesengerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MesengerApp.ViewModels;
public class RegisterViewModel :ViewModelBase
{
    private readonly IMessenger messenger;
    public RegisterViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
    }
    #region Commands

    private MyCommand? loginComand;

    public MyCommand LoginComand
    {
        get => this.loginComand ??= new MyCommand(
            action: () => BacktoLogin(),
            predicate: () => true);
        set => base.PropertyChange(out this.loginComand, value);
    }
    #endregion

    #region Methods
    void BacktoLogin()
    {
        try
        {
            //var user = this.usersRepository.Login(this.Login, this.Password);

            //this.Login = string.Empty;
            //this.Password = string.Empty;

            //this.messenger.Send(new SendLoginedUserMessage(user) { WhenLogined = DateTime.Now });
            this.messenger.Send(new NavigationMessage(typeof(LoginViewModel)));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                messageBoxText: ex.Message,
                caption: "User Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);
        }
    }
    #endregion

}

