using DataModel.Repositories;
using System;
using DataModel.DataProviders.Ef.Core.Repositories;
using System.IO;

namespace DataModel;

public class DataManager
{
    public IUserRep User { get; }

    private DataManager(IUserRep user)
    {
        User = user;
    }

    public static DataManager Get(DataProvidersList dataProviders)
    {
        switch (dataProviders)
        {
            case DataProvidersList.Json:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            case DataProvidersList.Txt:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            case DataProvidersList.Oracle:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            case DataProvidersList.SqLite:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            case DataProvidersList.MySql:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            case DataProvidersList.SqlServer:
                var sqlserver = new DataProviders.Ef.Contexts.SqlServerDbContext();
                sqlserver.Database.EnsureCreated();
                return new DataManager
                (
                    new EfUsers(sqlserver)
                );
            case DataProvidersList.PostgreSQL:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            default:
                throw new NotSupportedException("Поставщики данных неизвестен");
        }
    }
}