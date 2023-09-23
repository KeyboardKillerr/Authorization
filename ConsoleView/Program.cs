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
(string, string, string?, string?) result;

while (key != 'e' && key != 'е')
{
    Console.Write("Login: ");
    login = Console.ReadLine();
    Console.Write("Password: ");
    password = Console.ReadLine();
    Console.Write("Confirm password: ");
    confirm = Console.ReadLine();

    result = signup.Regin(login, password, confirm);
    if (result.Item1 == "True") Log.Information($"{login} {result.Item3} {result.Item4} Успешная регистрация");
    else Log.Warning($"{login} {result.Item3} {result.Item4} {result.Item2}");

    Console.WriteLine("Нажми любую клавишу чтобы продолжить; Е чтобы выйти. ");
    key = Console.ReadKey().KeyChar.ToString().ToLower().ToCharArray()[0];
    Console.WriteLine();
}

Log.CloseAndFlush();