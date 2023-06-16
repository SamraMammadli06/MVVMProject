using MesengerApp.Classes;
using MesengerApp.Data.Repositories;
using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesengerApp.ViewModels
{
    public class AboutUsViewModel :ViewModelBase
    {

        User? currentUser;
        UserDapperRepos UserDapperRepos = new UserDapperRepos();
        private readonly IMessenger messenger;
        public AboutUsViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            this.messenger.Subscribe<SendLoginedUserMessage>(obj =>
            {
                if (obj is SendLoginedUserMessage message)
                {
                    this.CurrentUser = message.LoginedUser;
                }
            });
            countUsers = UserDapperRepos.GetUsersCount();
            countMessages = UserDapperRepos.GetMessagesCount();
            countGroups = UserDapperRepos.GetGroupsCount();
        }
        public User? CurrentUser
        {
            get { return currentUser; }
            set => base.PropertyChange(out currentUser, value);
        }

        string countUsers;
        public string? CountUsers
        {
            get { return countUsers; }
            set => base.PropertyChange(out countUsers, value);
        }
        string countMessages;
        public string? CountMessages
        {
            get { return countMessages; }
            set => base.PropertyChange(out countMessages, value);
        }
        string countGroups;
        public string? CountGroups
        {
            get { return countGroups; }
            set => base.PropertyChange(out countGroups, value);
        }
        #region Commands
        private MyCommand? profileComand;
        private MyCommand? chatsComand;
        public MyCommand groupsComand;


        public MyCommand ProfileComand
        {
            get => this.profileComand ??= new MyCommand(
                action: () => Profile(),
                predicate: () => true);
            set => base.PropertyChange(out this.profileComand, value);
        }
        public MyCommand ChatsComand
        {
            get => this.chatsComand ??= new MyCommand(
                action: () => Chats(),
                predicate: () => true);
            set => base.PropertyChange(out this.chatsComand, value);
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

        void Chats()
        {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
        }
        #endregion
    }
}
