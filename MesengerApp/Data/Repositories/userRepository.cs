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
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
}

