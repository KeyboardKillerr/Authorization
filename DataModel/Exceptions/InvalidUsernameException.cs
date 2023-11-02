using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Exceptions;

public class InvalidUsernameException : ArgumentException
{
    private static readonly string messageBase = "Error in username";
    public InvalidUsernameException() : base(message: messageBase) { }
    public InvalidUsernameException(string message) : base(message: $"{messageBase} > {message}") { }
}
