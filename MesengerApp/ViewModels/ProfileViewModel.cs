using MesengerApp.Classes;
using MesengerApp.Data.Repositories;
using MesengerApp.Messager.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesengerApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {

        User? currentUser;
        private readonly IMessenger messenger;
        
        private readonly UserDapperRepos repos = new UserDapperRepos();
        private readonly userRepository userRepository = new userRepository();
        string errormessage;
        public string? ErrorMessage
        {
            get { return errormessage; }
            set => base.PropertyChange(out errormessage, value);
        }
        public ProfileViewModel(IMessenger messenger)
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
        private MyCommand? chatsComand;
        private MyCommand? aboutusComand;
        public MyCommand groupsComand;
        public MyCommand changeComand;

        public MyCommand ChangeComand
        {
            get => this.changeComand ??= new MyCommand(
                action: () => Change(),
                predicate: () => true);
            set => base.PropertyChange(out this.changeComand, value);
        }

        public MyCommand ChatsComand
        {
            get => this.chatsComand ??= new MyCommand(
                action: () => Chats(),
                predicate: () => true);
            set => base.PropertyChange(out this.chatsComand, value);
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
        void Change()
        {
            try
            {
                this.ErrorMessage = string.Empty;
                this.repos.UpdateUser(this.currentUser.Id, this.currentUser.Name, this.currentUser.Password, this.currentUser.Email, this.currentUser.Surname);
            }
            catch(SqlException ex)
            {
                ErrorMessage = ex.Message;
                this.currentUser = this.userRepository.GetUser(currentUser.Id);   
            }
        }
        void Chats()
        {
            this.ErrorMessage = string.Empty;
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
        }
        void Groups()
        {
            this.ErrorMessage = string.Empty;
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(GroupsViewModel)));
        }

        void AboutUs()
        {
            this.ErrorMessage = string.Empty;
            this.messenger.Send(new NavigationMessage(typeof(AboutUsViewModel)));
        }
        #endregion
    }
}
