using MesengerApp.Add;
using MesengerApp.Classes;
using System.Collections.Generic;
using System.Linq;

namespace MesengerApp.Data.Repositories;
public class userRepository
{
    MesengerAppDbContext context = new MesengerAppDbContext();
    public User Login(string name, string password)
    {
        var u = context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
        return u;
    }
    public User GetUser(int id)
    {
        var u = context.Users.FirstOrDefault(u => u.Id==id);
        return u;
    }
    public User AddUser(User user)
    {
        var u = context.Users.FirstOrDefault(u => u.Name == user.Name);
        if(u == null)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return u;
        }
        return u;
    }
    public List<string> GetUsersName(int id)
    {
        var query = context.Users.Where(u=>u.Id!=id).Select(u => u.Name);
        var r = query.ToList();
        return r;
    }

    public List<Chat> GetChat(int id,string sendername)
    {
        var query = context.Chats
          .Join(inner: context.Users,
          outerKeySelector: chat => chat.SenderId,
          innerKeySelector: user => user.Id,
          resultSelector: (chat, user) => new { Chat = chat, User = user })
         .Where(cu => cu.User.Name == sendername && cu.Chat.RecieverId == id)
         .Select(cu => cu.Chat);
        var r = query.ToList();
        return r;
    }
}

