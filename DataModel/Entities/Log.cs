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
    public string Login { get; internal init; } = null!;
    public string Pass { get; internal init; } = null!;
    public string Confirm { get; internal init; } = null!;
    public bool IsSuccessful { get; internal init; }
    public string? Error { get; internal init; }

    internal Log() { }
    public Log(bool isSuccessful, string? login = null, string? password = null, string? confirmationPassword = null, string? error = null)
    {
        if (string.IsNullOrWhiteSpace(login)) Login = "";
        else Login = login;

        if (string. IsNullOrWhiteSpace(password)) Pass = "";
        else Pass = password;

        if (string.IsNullOrWhiteSpace(confirmationPassword)) Confirm = "";
        else Confirm = confirmationPassword;

        Error = error;
        IsSuccessful = isSuccessful;
    }
}
