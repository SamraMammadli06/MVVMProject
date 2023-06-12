namespace MesengerApp.Messager.Messages;

using MesengerApp.Messages;
using System;

public class NavigationMessage : IMessage {
    public Type NavigateTo { get; set; }

    public NavigationMessage(Type navigateTo)
    {
        this.NavigateTo = navigateTo;
    }
}