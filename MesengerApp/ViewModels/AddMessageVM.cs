using MesengerApp.Classes;
using MesengerApp.Data.Repositories;
using MesengerApp.Messager.Messages;
using MesengerApp.Messages;
using MesengerApp.Services;
using MesengerApp.Tools;

namespace MesengerApp.ViewModels
{
    public class AddMessageVM :ViewModelBase
    {
        private IMessenger messenger;
        public User CurrentUser { get; private set; }
        UserDapperRepos repos = new UserDapperRepos();
        public AddMessageVM(IMessenger messenger)
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
        #region Props
        string name;
        public string? Name
        {
            get { return name; }
            set => base.PropertyChange(out name, value);
        }
        string tittle;
        public string? Tittle
        {
            get { return tittle; }
            set => base.PropertyChange(out tittle, value);
        }
        string message;
        public string? Message
        {
            get { return message; }
            set => base.PropertyChange(out message, value);
        }
        #endregion

        #region Commands
        private MyCommand? chatsComand;
        private MyCommand? aboutusComand;
        private MyCommand? profileComand;
        private MyCommand? sendComand;


        public MyCommand ProfileComand
        {
            get => this.profileComand ??= new MyCommand(
                action: () => Profile(),
                predicate: () => true);
            set => base.PropertyChange(out this.profileComand, value);
        }

        public MyCommand SendComand
        {
            get => this.sendComand ??= new MyCommand(
                action: () => Send(),
                predicate: () => true);
            set => base.PropertyChange(out this.sendComand, value);
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


        #endregion

        #region Methods
       
        void Chats()
        {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new SendAllUsers(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
        }
        void Send()
        {
            repos.SendChat(CurrentUser.Id, Name, Tittle, Message);
            this.Name = string.Empty;
            this.Tittle = string.Empty;
            this.Message = string.Empty;
        }
        void Profile()
        {
            this.messenger.Send(new SendLoginedUserMessage(CurrentUser));
            this.messenger.Send(new NavigationMessage(typeof(ChatsViewModel)));
        }
        void AboutUs()
        {
            this.messenger.Send(new NavigationMessage(typeof(AboutUsViewModel)));
        }
    }
    #endregion
}
