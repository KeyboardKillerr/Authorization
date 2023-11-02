using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repositories;

public interface ILogRep
{
    IQueryable<Log> Items { get; }
    Task<int> CreateAsync(Log table);
    Task<Log?> GetItemByLPCAsync(string? login, string? password, string? confirmation);
    Task<int> DeleteAsync(string? login, string? password, string? confirmation);
}
