namespace MesengerApp.Messager.Messages;

using MesengerApp.Classes;
using MesengerApp.Messages;
using System;

public class SendLoginedUserMessage : IMessage
{
    public User LoginedUser { get; set; }

    public SendLoginedUserMessage(User loginedUser)
    {
        this.LoginedUser = loginedUser;
    }
}