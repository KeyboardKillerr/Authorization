using NUnit.Framework;
using Azure.Identity;
using Control.Validation;
using DataModel;

namespace NUnitTests;

[TestFixture]
public class SignUpTest
{
    private Validator validator;

    [SetUp]
    public void SetUp()
    {
        validator = new Validator(DataManager.Get(DataProvidersList.SqlServer));
    }

    private static void CheckResult(ValidationResult result, string expectedStatus, string expectedMessage)
    {
        Assert.Multiple(() =>
        {
            Assert.That(result.StatusInfo.IsSuccessful, Is.EqualTo(expectedStatus));
            Assert.That(result.StatusInfo.Message, Is.EqualTo(expectedMessage));
        });
    }

    [TestCase("kk@mail.com", "Па!роль1", "Па!роль1", "False", "Пользователь с таким именем уже существует.")]
    [TestCase("kk@mail.ru", "Па!роль1", "Па!роль1", "True", "")]
    public void SignupTest_Normal(string login, string password, string confirm, string expectedStatus, string expectedMessage)
    {
        var res = validator.Validate(login, password, confirm);
        CheckResult(res, expectedStatus, expectedMessage);
    }

    [TestCase("", "Па!роль1", "Па!роль1", "False", "Имя пользователя не введено.")]
    [TestCase("kk@mail.com", "", "Па!роль1", "False", "Пароль не введён.")]
    [TestCase("kk@mail.com", "Па!роль1", "", "False", "Пароль подтверждения не введён.")]
    public void SignupTest_Empty(string login, string password, string confirm, string expectedStatus, string expectedMessage)
    {
        CheckResult(validator.Validate(login, password, confirm), expectedStatus, expectedMessage);
    }

    [TestCase(null, "Па!роль1", "Па!роль1", "False", "Имя пользователя не введено.")]
    [TestCase("kk@mail.com", null, "Па!роль1", "False", "Пароль не введён.")]
    [TestCase("kk@mail.com", "Па!роль1", null, "False", "Пароль подтверждения не введён.")]
    public void SignupTest_Null(string? login, string? password, string? confirm, string expectedStatus, string expectedMessage)
    {
        CheckResult(validator.Validate(login, password, confirm), expectedStatus, expectedMessage);
    }

    [TestCase("Usernam", "Па!роль1", "Па!роль1", "True", "")]
    [TestCase("User_name11", "Па!роль1", "Па!роль1", "True", "")]
    [TestCase("89990000000", "Па!роль1", "Па!роль1", "True", "")]
    [TestCase("7-999-000-0000", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    public void SignupTest_Username(string login, string password, string confirm, string expectedStatus, string expectedMessage)
    {
        CheckResult(validator.Validate(login, password, confirm), expectedStatus, expectedMessage);
    }

    [TestCase("kkmail.ru", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    [TestCase("kk@mailru", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    [TestCase("kkmailru", "Па!роль1", "Па!роль1", "True", "")]
    [TestCase("k@m.r", "Па!роль1", "Па!роль1", "True", "")]
    [TestCase("@.", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    [TestCase("@mail.ru", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    [TestCase("kk@.ru", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    [TestCase("kk@mail.", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    public void SignupTest_Email(string login, string password, string confirm, string expectedStatus, string expectedMessage)
    {
        CheckResult(validator.Validate(login, password, confirm), expectedStatus, expectedMessage);
    }

    [TestCase("+7-999-000-00-00", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    [TestCase("+7-999-000-0000", "Па!роль1", "Па!роль1", "True", "")]
    [TestCase("+7-999-0!0-0000", "Па!роль1", "Па!роль1", "False", "Имя пользователя введено неправильно.")]
    public void SignupTest_PhoneNumber(string login, string password, string confirm, string expectedStatus, string expectedMessage)
    {
        CheckResult(validator.Validate(login, password, confirm), expectedStatus, expectedMessage);
    }

    [TestCase("Username", "Pa!ssword1", "Pa!ssword1", "False", "Пароль введён неправильно.")]
    [TestCase("Username", "Па!роль", "Па!роль", "False", "Пароль введён неправильно.")]
    [TestCase("Username", "Пароль1", "Пароль1", "False", "Пароль введён неправильно.")]
    [TestCase("Username", "пароль", "пароль", "False", "Пароль введён неправильно.")]
    [TestCase("Username", "ПАРОЛЬ1!", "ПАРОЛЬ1!", "False", "Пароль введён неправильно.")]
    public void SignupTest_Password(string login, string password, string confirm, string expectedStatus, string expectedMessage)
    {
        CheckResult(validator.Validate(login, password, confirm), expectedStatus, expectedMessage);
    }
}
