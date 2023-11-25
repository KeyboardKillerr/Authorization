using DataModel;
using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests;

[TestFixture]
public class CRUDTest
{
    public DataManager DbConnection { get; set; }

    [SetUp]
    public void SetUp()
    {
        DbConnection = DataManager.Get(DataProvidersList.SqlServer);
    }

    [Test]
    public void LogCreate_Test()
    {
        Log log = new(true, "", "", "");
        DbConnection.Log.CreateAsync(log).Wait();
        var searchResult = DbConnection.Log.GetItemByLPCAsync("", "", "");
        searchResult.Wait();
        Assert.That(searchResult.Result, !Is.Null);

    }

    [Test]
    public void LogDelete_Test()
    {
        Log log = new(true, "", "", "");
        DbConnection.Log.CreateAsync(log).Wait();

        DbConnection.Log.DeleteAsync("", "", "").Wait();
        var searchResult = DbConnection.Log.GetItemByLPCAsync("", "", "");
        searchResult.Wait();
        Assert.That(searchResult.Result, Is.Null);
    }
}
