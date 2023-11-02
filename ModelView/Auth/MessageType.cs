﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Auth;

public enum MessageType
{
    EmptyLogin,
    EmptyPassword,
    EmptyConfirm,
    InvalidUsername,
    UserExists,
    WrongPassword,
    WrongConfirmationPassword,
    Nothing
}
