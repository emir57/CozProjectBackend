﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
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

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = _context.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
