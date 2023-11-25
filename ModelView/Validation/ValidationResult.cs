using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Validation;

public readonly struct ValidationResult
{
    public Status StatusInfo { get; init; }
    public InputData InputInfo { get; init; }
    internal ValidationResult(Status status, InputData inputData)
    {
        StatusInfo = status;
        InputInfo = inputData;
    }
}
