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

namespace Control.Validation;

public class Validator
{
    private DataManager Data { get; init; }

    public Validator(DataManager dataManager)
    {
        Data = dataManager;
    }

    public ValidationResult Validate(string? login, string? password, string? confirm)
    {
        InputData inputData = new();
        Status result = new(true);

        if (string.IsNullOrWhiteSpace(login))
        {
            result = new(false, MessageType.EmptyLogin);
            return new(result, inputData);
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            result = new(false, MessageType.EmptyPassword);
            return new(result, inputData);
        }
        if (string.IsNullOrWhiteSpace(confirm))
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

        return new(result, inputData);
    }
}
