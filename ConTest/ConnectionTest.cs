using NUnit.Framework;
using DataModel;

namespace NUnitTests;

[TestFixture]
public class ConnectionTest
{
    [Test]
    public void DbConnection()
    {
        DataManager dm = DataManager.Get(DataProvidersList.SqlServer);
        Assert.Pass();
    }
}