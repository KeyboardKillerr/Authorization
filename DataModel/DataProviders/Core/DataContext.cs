using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModel.DataProviders.Ef.Core;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder mb)
    {
        var client = new User()
        {
            Id = Guid.NewGuid(),
            Login = "root",
            Password = Entities.User.GetHashString("root")
        };
        mb.Entity<User>().HasData(client);
    }
}
