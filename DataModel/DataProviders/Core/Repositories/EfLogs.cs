using DataModel.DataProviders.Ef.Core;
using DataModel.Entities;
using DataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataProviders.Core.Repositories;

public class EfLogs : ILogRep
{
    protected readonly DataContext Context;
    internal EfLogs(DataContext context) => Context = context;
    public IQueryable<Log> Items => Context.Logs;

    public async Task<int> CreateAsync(Log table)
    {
        var item = await Items.FirstOrDefaultAsync(x => x.Login == table.Login && x.Pass == table.Pass && x.Confirm == table.Confirm);
        if (item == default)
        {
            await Context.AddAsync(table);
            return await Context.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<Log?> GetItemByLPCAsync(string? login, string? password, string? confirmation)
    {
        return await Items.FirstOrDefaultAsync(x => x.Login == login && x.Pass == password && x.Confirm == confirmation);
    }

    public async Task<int> DeleteAsync(string? login, string? password, string? confirmation)
    {
        var item = await Items.FirstOrDefaultAsync(x => x.Login == login && x.Pass == password && x.Confirm == confirmation);
        if (item != default)
        {
            Context.Remove(item);
            return await Context.SaveChangesAsync();
        }
        return 0;
    }
}
