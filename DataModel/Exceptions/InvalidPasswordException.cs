﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Exceptions;

public class InvalidPasswordException : ArgumentException
{
    public InvalidPasswordException() : base(message: "Error in password") { }
}
