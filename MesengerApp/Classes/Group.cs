using System.Collections.Generic;

namespace MesengerApp.Classes;
public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Message { get; set; }
    public List<User> Users { get; set; }
}

