using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModel.DataProviders.Core;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; init; } = null!;
    public DbSet<Log> Logs { get; init; } = null!;
    protected override void OnModelCreating(ModelBuilder mb)
    {
        var client = new User()
        {
            Login = "kk@mail.com",
            Password = User.GetHashString("Пароль1!")
        };
        mb.Entity<User>().HasData(client);
    }
}
