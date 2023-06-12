using MesengerApp.Services;
using MesengerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesengerApp.ViewModels;
public class RegisterViewModel :ViewModelBase
{
    private readonly IMessenger messenger;
    public RegisterViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
    }
}

