using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialsSender;
using Control.Auth;
using DataModel;

namespace Control;

public sealed class MainController
{
    private readonly SmsSender smsSender = new();
    private readonly Authenticator authenticator = new(DataManager.Get(DataProvidersList.SqlServer));
    public AuthenticationResult Authunticate(string username, string password, string confirmationPassword)
    {
        authenticator
        smsSender.Send("message", "phonenumber");
    }
}
