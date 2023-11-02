using DataModel.Repositories;
using System;
using System.IO;
using DataModel.DataProviders.Core.Repositories;

namespace DataModel;

public class DataManager
{
    public IUserRep User { get; }
    public ILogRep Log { get; }

    private DataManager(IUserRep user, ILogRep log)
    {
        User = user;
        Log = log;
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
                var sqlserver = new DataProviders.Contexts.SqlServerDbContext();
                sqlserver.Database.EnsureCreated();
                return new DataManager
                (
                    new EfUsers(sqlserver),
                    new EfLogs(sqlserver)
                );
            case DataProvidersList.PostgreSQL:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            default:
                throw new NotSupportedException("Поставщики данных неизвестен");
        }
    }
}