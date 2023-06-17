using MesengerApp.Classes;
using MesengerApp.Data.Repositories;
using MesengerApp.Messager.Messages;
using MesengerApp.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;
using System.Collections.ObjectModel;
using System.Windows;

namespace MesengerApp.ViewModels;
public class ChatsViewModel : ViewModelBase
{
    User currentUser;
    userRepository userRepository = new userRepository();
    public User CurrentUser
    {
        get { return currentUser; }
        set => base.PropertyChange(out currentUser, value);
    }

    private readonly IMessenger messenger;
    ObservableCollection<User> users;
    public ObservableCollection<User> Users { get { return users; } 
        set => base.PropertyChange(out users,value);
    }
    ObservableCollection<Chat> chats;
    public ObservableCollection<Chat> Chats
    {
        get { return chats; }
        set => base.PropertyChange(out chats, value);
    }
    public ChatsViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
        this.messenger.Subscribe<SendLoginedUserMessage>(obj =>
        {
            if (obj is SendLoginedUserMessage message)
            {
                this.CurrentUser = message.LoginedUser;
            }
        });
        this.messenger.Subscribe<SendAllUsers>(obj =>
        {
            if (obj is SendAllUsers message)
            {
                this.Users = message.Users;
            }
        });
        
    }

    public string selectedItem;
    public string SelectedItem
    {
        get {
            this.Chats = new ObservableCollection<Chat>(userRepository.GetChat(currentUser.Id, sendername: selectedItem));
            return selectedItem;
        }
        set {
            base.PropertyChange(out selectedItem, value); }
    }

    #region Commands
    private MyCommand? profileComand;
    private MyCommand? aboutusComand;
    private MyCommand? newMessageComand;

    public MyCommand NewMessageComand
    {
        get => this.newMessageComand ??= new MyCommand(
            action: () => NewMessage(),
            predicate: () => true);
        set => base.PropertyChange(out this.newMessageComand, value);
    }
    public MyCommand ProfileComand
    {
        get => this.profileComand ??= new MyCommand(
            action: () => Profile(),
            predicate: () => true);
        set => base.PropertyChange(out this.profileComand, value);
    }
    public MyCommand AboutusComand
    {
        get => this.aboutusComand ??= new MyCommand(
            action: () => AboutUs(),
            predicate: () => true);
        set => base.PropertyChange(out this.aboutusComand, value);
    }

  
    #endregion

    #region Methods
    void Profile()
    {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ProfileViewModel)));
    }
    void NewMessage()
    {
        this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
        this.messenger.Send(new NavigationMessage(typeof(AddMessageVM)));
    }
    void AboutUs()
    {
        this.messenger.Send(new NavigationMessage(typeof(AboutUsViewModel)));    
    }
    #endregion
}

