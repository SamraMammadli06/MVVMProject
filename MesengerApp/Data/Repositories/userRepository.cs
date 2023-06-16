using MesengerApp.Add;
using MesengerApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

