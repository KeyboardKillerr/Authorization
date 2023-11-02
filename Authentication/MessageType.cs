using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelView.Authentication;

public enum MessageType
{
    EmptyLogin,
    EmptyPassword,
    EmptyConfirm,
    InvalidUsername,
    UserExists,
    WrongPassword,
    Nothing
}
