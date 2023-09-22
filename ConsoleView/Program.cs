using Serilog;
using ModelView;

string template = "{Timestamp:HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exception}";
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
.WriteTo.Console(outputTemplate: template)
.WriteTo.File("logs/file_.txt", outputTemplate: template)
.CreateLogger();
Log.Verbose("Logger configurated");
Log.Information("App started");

Signup signup = new();

char key = ' ';
string? login;
string? password;
string? confirm;
(string, string) result;

while (key != 'e')
{
    Console.Write("Login: ");
    login = Console.ReadLine();
    Console.Write("Password: ");
    password = Console.ReadLine();
    Console.Write("Confirm password: ");
    confirm = Console.ReadLine();

    result = signup.Regin(login, password, confirm);
    if (result.Item1 == "True") Log.Information($"{login} {password} {password} Успешная регистрация");
    else Log.Warning($"{login} {password} {password} {result.Item2}");

    key = Console.ReadKey().KeyChar;
}

Log.CloseAndFlush();