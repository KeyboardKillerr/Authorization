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
        //User user = new("kk@mail.com", User.GetHashString("Пароль1!"));
        //mb.Entity<User>().HasData(user);
    }
}
