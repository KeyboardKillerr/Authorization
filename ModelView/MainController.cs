using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialsSender;
using Control.Validation;
using DataModel;
using Control.Readers;
using DataModel.Entities;
using System.ComponentModel.Design;

namespace Control;

public sealed class MainController
{
    private readonly DataManager dataManager = DataManager.Get(DataProvidersList.SqlServer);
    private Validator validator { get; init; }

    private IReader Reader { get; init; }
    private ISender Sender { get; init; }

    public MainController(IReader reader, ISender sender)
    {
        validator = new(dataManager);

        Reader = reader;
        Sender = sender;
    }

    public bool Authenticate()
    {
        InputData input = Reader.Read();
        ValidationResult validationResult = validator.Validate(input.Login, input.Password, input.ConfirmationPassword);

        if (MatchStatusIsSuccessful(validationResult.StatusInfo.IsSuccessful))
        {
            User user = new(input.Login!, input.Password!);
            dataManager.User.UpdateAsync(user);
            Sender.Send("OK");
        }
        else Sender.Send("NOK");

        Log log = new(
            MatchStatusIsSuccessful(validationResult.StatusInfo.IsSuccessful),
            input.Login,
            input.Password,
            input.ConfirmationPassword,
            validationResult.StatusInfo.Message);
        dataManager.Log.CreateAsync(log);

        return MatchStatusIsSuccessful(validationResult.StatusInfo.IsSuccessful);
    }

    private static bool MatchStatusIsSuccessful(string status) => status switch
    {
        "True" => true,
        "False" => false,
        _ => throw new ArgumentException(message:status)
    };
}
