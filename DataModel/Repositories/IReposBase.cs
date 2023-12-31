﻿using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Repositories;

public interface IReposBase<TTable> where TTable : class
{
    IQueryable<TTable> Items { get; }
    Task<int> CreateAsync(TTable table);
    Task<TTable?> GetItemByIdAsync(Guid id);
    Task<int> UpdateAsync(TTable table);
    Task<int> DeleteAsync(Guid id);
}