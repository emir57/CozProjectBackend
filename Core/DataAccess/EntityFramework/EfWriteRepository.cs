﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework;

public class EfWriteRepository<T> : IWriteRepository<T>
    where T : class, IEntity, new()
{
    private readonly DbContext _context;
    public EfWriteRepository(DbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry = await _context.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(List<T> entities)
    {
        await _context.AddRangeAsync(entities);
    }

    public bool Delete(T entity)
    {
        EntityEntry<T> entityEntry = _context.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public void DeleteRange(List<T> entities)
    {
        _context.RemoveRange(entities);
    }

    public async Task DeleteRangeAsync(int[] ids)
    {
        List<T> deletedEntities = await Table.Where(t => ids.Any(i => t.Id == i)).Select(t => new T { Id = t.Id }).ToListAsync();
        DeleteRange(deletedEntities);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public bool Update(T entity)
    {
        EntityEntry<T> entityEntry = _context.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(List<T> entities)
    {
        _context.UpdateRange(entities);
    }
}
