using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Core.Extensions
{
    public static class ContextExtensions
    {
        public static void SetEntityState(this IEnumerable<EntityEntry<IEntity>> entries)
        {
            foreach (var entry in entries)
            {
                var _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => entry.Entity.UpdatedDate = DateTime.Now,
                    EntityState.Deleted => entry.Entity.DeletedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
        }
    }
}
