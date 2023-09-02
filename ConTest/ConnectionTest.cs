using NUnit.Framework;
using DataModel;

namespace NUnitTests;

[TestFixture]
public class ConnectionTest
{
    [Test]
    public void RootAuth()
    {
        DataManager dm = DataManager.Get(DataProvidersList.SqlServer);
        Assert.Pass();
    }
}