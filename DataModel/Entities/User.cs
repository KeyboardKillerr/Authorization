using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataModel.Helpers;
using DataModel.Exceptions;
using Microsoft.Identity.Client;

namespace DataModel.Entities;

public class User : EntityBase
{
    public string Login { get; internal set; } = null!;
    public string Password { get; internal set; } = null!;

    internal User() { }
    public User(string login, string password)
    {
        if (!UserValidation.ValidateLogin(login)) throw new InvalidUsernameException(login);
        if (!UserValidation.ValidatePassword(password)) throw new InvalidPasswordException();

        Login = login;
        Password = password;
    }

    private static byte[] GetHash(string inputString)
    {
        return SHA256.HashData(Encoding.UTF8.GetBytes(inputString));
    }

    public static string GetHashString(string inputString)
    {
        StringBuilder sb = new();
        foreach (byte b in GetHash(inputString))
            sb.Append(b.ToString("X2"));

        return sb.ToString();
    }
}