using NUnit.Framework;
using ModelView;
using Azure.Identity;

namespace NUnitTests;

[TestFixture]
public class SignUpTest
{
    private Signup _sp;

    [SetUp]
    public void SetUp()
    {
        _sp = new();
    }

    [TestCase("kk@mail.com", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.ru", "Па!роль1", "Па!роль1", ExpectedResult = "True")]

    [TestCase("", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.com", "", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.com", "Па!роль1", "", ExpectedResult = "False")]

    [TestCase(null, "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.com", null, "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.com", "Па!роль1", null, ExpectedResult = "False")]

    [TestCase("Username", "Па!роль1", "Па!роль1", ExpectedResult = "True")]
    [TestCase("User_name", "Па!роль1", "Па!роль1", ExpectedResult = "True")]
    [TestCase("Username11", "Па!роль1", "Па!роль1", ExpectedResult = "True")]
    [TestCase("User_name11", "Па!роль1", "Па!роль1", ExpectedResult = "True")]

    [TestCase("kkmail.ru", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mailru", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.ru", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kkmailru", "Па!роль1", "Па!роль1", ExpectedResult = "True")]
    [TestCase("k@m.r", "Па!роль1", "Па!роль1", ExpectedResult = "True")]
    [TestCase("@.", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("@mail.ru", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@.ru", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("kk@mail.ru", "Па!роль1", "Па!роль1", ExpectedResult = "False")]

    [TestCase("+7-999-000-00-00", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("+7-999-000-0000", "Па!роль1", "Па!роль1", ExpectedResult = "True")]
    [TestCase("7-999-000-0000", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("+7-999-0!0-0000", "Па!роль1", "Па!роль1", ExpectedResult = "False")]
    [TestCase("89990000000", "Па!роль1", "Па!роль1", ExpectedResult = "True")]

    [TestCase("Username", "Pa!ssword1", "Pa!ssword1", ExpectedResult = "False")]
    [TestCase("Username", "Па!роль", "Па!роль", ExpectedResult = "False")]
    [TestCase("Username", "Пароль1", "Пароль1", ExpectedResult = "False")]
    [TestCase("Username", "Пароль", "Пароль", ExpectedResult = "False")]
    public string SignupTest(string? login, string? password, string? confirm)
    {
        return _sp.Regin(login, password, confirm).Item1;
    }
}
