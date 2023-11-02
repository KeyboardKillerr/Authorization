using NUnit.Framework;
using DataModel;

namespace NUnitTests;

[TestFixture]
public class ConnectionTest
{
    [Test]
    public void DbConnection()
    {
        _ = DataManager.Get(DataProvidersList.SqlServer);
        Assert.Pass();
    }
}