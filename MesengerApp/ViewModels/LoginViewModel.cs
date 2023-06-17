using MesengerApp.Tools;
using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using System;
using System.Windows;
using MesengerApp.Data.Repositories;
using MesengerApp.Messages;

namespace MesengerApp.ViewModels;
public class LoginViewModel : ViewModelBase
{
    private readonly userRepository userRepository = new userRepository();
    private readonly IMessenger messenger;
    public LoginViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
    }


    #region Properities

    private string? name;
    public string? Name
    {
        get { return name; }
        set => base.PropertyChange(out name, value);
    }

    private string? password;
    public string? Password
    {
        get { return password; }
        set => base.PropertyChange(out password, value);
    }

    private string? errormessage;
    public string? ErrorMessage
    {
        get { return errormessage; }
        set=>base.PropertyChange(out errormessage, value);
    }
    #endregion

    #region Commands

    private MyCommand? registerComand;
    private MyCommand? loginComand;

    public MyCommand RegisterComand
    {
        get => this.registerComand ??= new MyCommand(
            action: () => RegisterUser(),
            predicate: () => true);
        set => base.PropertyChange(out this.registerComand, value);
    }
    public MyCommand LoginComand
    {
        get => this.loginComand ??= new MyCommand(
            action: () => LoginUser(),
            predicate: () => !(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password)));
        set => base.PropertyChange(out this.loginComand, value);
    }
    #endregion

    #region Methods
    void RegisterUser()
    {
        try
        {
            this.messenger.Send(new NavigationMessage(typeof(RegisterViewModel)));
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
    void LoginUser()
    {
        try
        {
            var user = this.userRepository.Login(this.Name, this.Password);

            this.Name = string.Empty;
            this.Password = string.Empty;
            if (user != null)
            {
                this.messenger.Send(new SendLoginedUserMessage(user));
                this.messenger.Send(new SendAllUsers(user));
                this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
            }
            else
            {
                ErrorMessage = "User not found";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
    #endregion
}

