﻿using DataModel.Entities;
using DataModel.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataModel.DataProviders.Core.Repositories;

public class EfUsers : IUserRep
{
    protected readonly DataContext Context;
    internal EfUsers(DataContext context) => Context = context;
    public IQueryable<User> Items => Context.Users;

    public async Task<int> CreateAsync(User table)
    {
        var item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id || x.Login == table.Login);
        if (item == default)
        {
            await Context.AddAsync(table);
            return await Context.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<User?> GetItemByIdAsync(Guid id)
    {
        return await Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> UpdateAsync(User table)
    {
        var item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id);
        if (item != default)
        {
            item.Login = table.Login;
            item.Password = table.Password;
            Context.Update(item);
        }
        else await Context.AddAsync(table);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var item = await Items.FirstOrDefaultAsync(x => x.Id == id);
        if (item != default)
        {
            Context.Remove(item);
            return await Context.SaveChangesAsync();
        }
        return 0;
    }
}
