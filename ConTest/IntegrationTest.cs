using Control;
using Control.Readers;
using Control.Validation;
using DataModel;
using DataModel.Entities;
using Moq;
using SocialsSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests;

[TestFixture]
public class IntegrationTest
{
    [Test]
    public void SuccessfulAuth_SenderTest()
    {
        var mockReader = new Mock<IReader>();
        var mockSender = new Mock<ISender>();

        var inputData = new InputData("kk@mail.ru", "Па!роль1", "Па!роль1");
        mockReader.Setup(x => x.Read()).Returns(inputData);

        var controller = new MainController(mockReader.Object, mockSender.Object);

        var result = controller.Authenticate();
        Assert.That(result, Is.True);
        mockSender.Verify(x => x.Send("OK"), Times.Once);
    }

    [Test]
    public void UnsuccessfulAuth_SenderTest()
    {
        var mockReader = new Mock<IReader>();
        var mockSender = new Mock<ISender>();

        var inputData = new InputData("", "Па!роль1", "Па!роль1");
        mockReader.Setup(x => x.Read()).Returns(inputData);

        var controller = new MainController(mockReader.Object, mockSender.Object);

        var result = controller.Authenticate();
        Assert.That(result, Is.False);
        mockSender.Verify(x => x.Send("NOK"), Times.Once);
    }

    [Test]
    public void SuccessfulAuth_LogTest()
    {
        var dbConnection = DataManager.Get(DataProvidersList.SqlServer);
        var mockReader = new Mock<IReader>();
        var mockSender = new Mock<ISender>();

        var inputData = new InputData("kkk@mail.ru", "Па!роль1", "Па!роль1");
        mockReader.Setup(x => x.Read()).Returns(inputData);

        var controller = new MainController(mockReader.Object, mockSender.Object);

        var result = controller.Authenticate();
        Assert.That(result, Is.True);

        var searchResult = dbConnection.Log.GetItemByLPCAsync("kkk@mail.ru", "Па!роль1", "Па!роль1");
        searchResult.Wait();
        Assert.That(searchResult, !Is.Null);
    }

    [Test]
    public void UnsuccessfulAuth_LogTest()
    {
        var dbConnection = DataManager.Get(DataProvidersList.SqlServer);
        var mockReader = new Mock<IReader>();
        var mockSender = new Mock<ISender>();

        var inputData = new InputData("", "Па!роль1", "Па!роль1");
        mockReader.Setup(x => x.Read()).Returns(inputData);

        var controller = new MainController(mockReader.Object, mockSender.Object);

        var result = controller.Authenticate();
        Assert.That(result, Is.False);

        var searchResult = dbConnection.Log.GetItemByLPCAsync("", "Па!роль1", "Па!роль1");
        searchResult.Wait();
        Assert.That(searchResult, !Is.Null);
    }
}
