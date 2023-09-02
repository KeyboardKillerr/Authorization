using DataModel.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModel.DataProviders.Ef.Contexts;

public class SqlServerDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source = DBSRV\max2022; Initial Catalog = KMVAuthAutoTest; Integrated Security = True; TrustServerCertificate=True");
    }
}
