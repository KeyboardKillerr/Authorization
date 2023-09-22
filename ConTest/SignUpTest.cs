using NUnit.Framework;
using ModelView;
using Azure.Identity;

namespace NUnitTests;

[TestFixture]
public class SignUpTest
{
    [Test]
    public void SignUps()
    {
        Signup sp = new();
        string?[] usernames = { "lll", "", null, "KeyboardKiller", "KK_1337", "+7-000-000-00-00", "80001112233", "nail@mail.com", "@." };
        string?[] password = { "пароль12345!", "lololololol", "РеальныйПароль!1", null, "__12ф", " циомгцОИТЩГТ__!1112 ", "П_аРол808?", "Сработает??7?", "" };
        string?[] confirm = { "пароль12345!", "lololololol", "РеальныйПароль!1", null, "__12ф", " циомгцОИТЩГТ__!1112 ", "аРол808?", "Сработ", "" };
        for (int i = 0; i < usernames.Length; i++)
        {
            sp.Regin(usernames[i], password[i], confirm[i]);
        }
    }
}
