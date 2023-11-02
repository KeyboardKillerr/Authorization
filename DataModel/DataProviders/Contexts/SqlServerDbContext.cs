using DataModel.DataProviders.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModel.DataProviders.Contexts;

public class SqlServerDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source = localhost; Initial Catalog = AuthTest; Integrated Security = True; TrustServerCertificate=True");
    }
}
