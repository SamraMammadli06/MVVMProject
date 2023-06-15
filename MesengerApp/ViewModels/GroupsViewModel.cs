using MesengerApp.Classes;
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
    public class GroupsViewModel : ViewModelBase
    {

        User currentUser;
        private readonly IMessenger messenger;
        public GroupsViewModel(IMessenger messenger)
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
        public MyCommand chatsComand;


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

        public MyCommand ChatsComand
        {
            get => this.chatsComand ??= new MyCommand(
                action: () => Chats(),
                predicate: () => true);
            set => base.PropertyChange(out this.chatsComand, value);
        }
        #endregion

        #region Methods
        void Profile()
        {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ProfileViewModel)));
        }
        void Chats()
        {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
        }

        void AboutUs()
        {
            this.messenger.Send(new NavigationMessage(typeof(AboutUsViewModel)));
        }
        #endregion
    }
}
