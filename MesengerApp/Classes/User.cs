using System.Collections.Generic;

namespace MesengerApp.Classes;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Surname { get; set; }
    public List<Chat> Chats { get; set; }
    public List<Group> Groups { get; set; }
}

