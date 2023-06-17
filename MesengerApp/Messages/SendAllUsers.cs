using MesengerApp.Classes;
using MesengerApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesengerApp.Messages
{
    public class SendAllUsers :IMessage
    {
        public ObservableCollection<User> Users { get; set; }
        private readonly userRepository userRepository = new userRepository();

        public SendAllUsers(User loginedUser )
        {
            this.Users =new ObservableCollection<User>(userRepository.GetUsers(loginedUser.Id));
        }
    }
}
