using MesengerApp.Classes;
using MesengerApp.Classes.QueriesClasses;
using MesengerApp.Data.Repositories;
using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;
using System.Collections.ObjectModel;

namespace MesengerApp.ViewModels;
public class ChatsViewModel : ViewModelBase
{
    User? currentUser;
    userRepository userRepository = new userRepository();

    ObservableCollection<UserChat> UserChats { get; set; }
    private readonly IMessenger messenger;
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

    }
    public User? CurrentUser
    {
        get { return currentUser; }
        set => base.PropertyChange(out currentUser, value);
    }
    

    #region Commands
    private MyCommand? profileComand;
    private MyCommand? aboutusComand;
    public MyCommand? groupsComand;


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

    public MyCommand GroupsComand
    {
        get => this.groupsComand ??= new MyCommand(
            action: () => Groups(),
            predicate: () => true);
        set => base.PropertyChange(out this.groupsComand, value);
    }
    #endregion

    #region Methods
    void Profile()
    {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ProfileViewModel)));
    }
    void Groups()
    {
        this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
        this.messenger.Send(new NavigationMessage(typeof(GroupsViewModel)));
    }

    void AboutUs()
    {
        this.messenger.Send(new NavigationMessage(typeof(AboutUsViewModel)));    
    }
    #endregion
}

