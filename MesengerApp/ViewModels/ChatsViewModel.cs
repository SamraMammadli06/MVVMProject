using MesengerApp.Classes;
using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesengerApp.ViewModels;
public class ChatsViewModel : ViewModelBase
{
    User currentUser;
    private readonly IMessenger messenger;
    public ChatsViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
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

