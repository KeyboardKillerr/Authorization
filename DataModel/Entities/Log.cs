using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities;

[PrimaryKey(nameof(Login), nameof(Pass), nameof(Confirm))]
public class Log
{
    public string Login { get; private init; } = null!;
    public string Pass { get; private init; } = null!;
    public string Confirm { get; private init; } = null!;
    public string Result { get; private init; } = null!;
    public string? Error { get; private init; }

    public Log(string? login, string? password, string? confirmationPassword, string result, string? error)
    {
        if (string.IsNullOrEmpty(login)) Login = "";
        else Login = login;

        if (string.IsNullOrEmpty(password)) Pass = "";
        else Pass = password;

        if (string.IsNullOrEmpty(confirmationPassword)) Confirm = "";
        else Confirm = confirmationPassword;

        Error = error;
        Result = result;
    }
}
