using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DataModel.Entities;
using DataModel.Helpers;
using Azure.Core;
using DataModel;

namespace Control.Auth;

public class Authenticator
{
    private readonly DataManager Data;

    public Authenticator(DataManager dataManager)
    {
        Data = dataManager;
        Data = DataManager.Get(DataProvidersList.SqlServer);
    }

    public AuthenticationResult Regin(string? login, string? password, string? confirm, bool writeChanges = false)
    {
        var inputData = new InputData();
        var result = new Status(true);

        if (string.IsNullOrEmpty(login))
        {
            result = new(false, MessageType.EmptyLogin);
            return new(result, inputData);
        }
        if (string.IsNullOrEmpty(password))
        {
            result = new(false, MessageType.EmptyPassword);
            return new(result, inputData);
        }
        if (string.IsNullOrEmpty(confirm))
        {
            result = new(false, MessageType.EmptyConfirm);
            return new(result, inputData);
        }

        login = login.Trim();
        password = password.Trim();
        confirm = confirm.Trim();

        inputData = new(login, User.GetHashString(password), User.GetHashString(confirm));

        if (!UserValidation.ValidateLogin(login))
        {
            result = new(false, MessageType.InvalidUsername);
            return new(result, inputData);
        }
        if (Data.User.Items.FirstOrDefault(u => u.Login == login) != default)
        {
            result = new(false, MessageType.UserExists);
            return new(result, inputData);
        }
        if (!UserValidation.ValidatePassword(password))
        {
            result = new(false, MessageType.WrongPassword);
            return new(result, inputData);
        }
        if (confirm != password)
        {
            result = new(false, MessageType.WrongConfirmationPassword);
            return new(result, inputData);
        }
        if (writeChanges)
        {
            password = User.GetHashString(password);

            User newUser = new(login, password);
            Data.User.CreateAsync(newUser);

            Log newLog = new()
            {
                Login = login,
                Pass = password,
                Confirm = confirm,
                Error = null,
                Result = "Success"
            };
            Data.Log.CreateAsync(newLog);
        }

        return new(result, inputData);
    }
}
