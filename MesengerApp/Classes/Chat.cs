namespace MesengerApp.Classes;
public class Chat
{
    public int Id { get; set; }
    public string? Message { get; set; }  
    public string? Title { get; set; }

    public User Sender { get; set; }
    public int SenderId { get; set; }
    public int RecieverId { get; set; }

}

