using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelView.Authentication;

public readonly struct InputData
{
    public string? Login { get; init; }
    public string? Password { get; init; }
    public string? ConfirmationPassword { get; init; }
    internal InputData(string? login = null, string? password = null, string? confirmationPassword = null)
    {
        Login = login;
        Password = password;
        ConfirmationPassword = confirmationPassword;
    }
}
