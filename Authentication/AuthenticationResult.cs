using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelView.Authentication;

public readonly struct AuthenticationResult
{
    public Status StatusInfo { get; init; }
    public InputData InputInfo { get; init; }
    public AuthenticationResult(Status status, InputData inputData)
    {
        StatusInfo = status;
        InputInfo = inputData;
    }
}
