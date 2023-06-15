using MesengerApp.Classes;
using MesengerApp.Data.Repositories;
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
    private readonly userRepository userRepository = new userRepository();
    public RegisterViewModel(IMessenger messenger)
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
        set => base.PropertyChange(out errormessage, value);
    }
    private string? conpassword;
    public string? ConPassword
    {
        get { return conpassword; }
        set => base.PropertyChange(out conpassword, value);
    }

    private string? email;
    public string? Email
    {
        get { return email; }
        set => base.PropertyChange(out email, value);
    }
    private string? surname;
    public string? Surname
    {
        get { return surname; }
        set => base.PropertyChange(out surname, value);
    }

  
    #endregion

    #region Commands

    private MyCommand? loginComand;
    private MyCommand? submitComand;

    public MyCommand LoginComand
    {
        get => this.loginComand ??= new MyCommand(
            action: () => BacktoLogin(),
            predicate: () => true);
        set => base.PropertyChange(out this.loginComand, value);
    }
    public MyCommand SubmitCommand
    {
        get => this.submitComand ??= new MyCommand(
        action: () => SubmitUser(),
        predicate: () => !(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)||string.IsNullOrEmpty(conpassword)));
        set => base.PropertyChange(out this.submitComand, value);
    }
    #endregion

    #region Methods
    void SubmitUser()
    {
        try
        {

            if (password==conpassword)
            {
                User user = new User()
                {
                    Name =this.name,
                    Surname = this.surname,
                    Email = this.email,
                    Password = this.password,
                };
                this.userRepository.AddUser(user);
                this.messenger.Send(new SendLoginedUserMessage(user));
                this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
            }
            else
            {
                ErrorMessage = "Enter Password Correctly";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
    void BacktoLogin()
    {
        try
        { 
            this.name=string.Empty;
            this.email=string.Empty;
            this.password=string.Empty;
            this.conpassword=string.Empty;
            this.surname=string.Empty;
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

