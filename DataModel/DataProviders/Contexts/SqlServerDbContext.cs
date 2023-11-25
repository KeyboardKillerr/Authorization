using DataModel.DataProviders.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModel.DataProviders.Contexts;

public class SqlServerDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        //Data Source = localhost; User ID = DevAccount; Password = SimplePassword!; Initial Catalog = AuthTest; Integrated Security = True; TrustServerCertificate=True
        builder.UseSqlServer(@"Data Source = localhost; Initial Catalog = AuthTest; Integrated Security = True; TrustServerCertificate=True");
        //builder.UseSqlServer(@"Data Source = localhost; User ID = DevAccount; Password = SimplePassword!; Initial Catalog = AuthTest; Integrated Security = True; TrustServerCertificate=True");
    }
}
