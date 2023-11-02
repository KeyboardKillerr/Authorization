using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Auth;

public readonly struct Status
{
    public string IsSuccessful { get; init; }
    public string Message { get; init; }
    internal Status(bool status, MessageType message = MessageType.Nothing)
    {
        if (status) IsSuccessful = "True";
        else IsSuccessful = "False";

        Message = MessageToString(message);
    }

    private static string MessageToString(MessageType message) => message switch
    {
        MessageType.Nothing => "",
        MessageType.EmptyLogin => "Имя пользователя не введено.",
        MessageType.EmptyPassword => "Пароль не введён.",
        MessageType.EmptyConfirm => "Пароль подтверждения не введён.",
        MessageType.InvalidUsername => "Имя пользователя введено неправильно.",
        MessageType.WrongPassword => "Пароль введён неправильно.",
        MessageType.UserExists => "Пользователь с таким именем уже существует.",
        MessageType.WrongConfirmationPassword => "Пароли не совпадают",

        _ => throw new NotImplementedException(message: $"""Необработанный вариант аргумента: "{message}" """)
    };
}
