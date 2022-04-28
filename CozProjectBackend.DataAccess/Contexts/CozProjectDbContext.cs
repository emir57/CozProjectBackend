using Core.Entities;
using Core.Entities.Concrete;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Contexts
{
    public class CozProjectDbContext : DbContext
    {
        public CozProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<IEntity>();
            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    EntityState.Deleted => data.Entity.DeletedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryComplete> CategoryCompletes { get; set; }
        public DbSet<QuestionComplete> QuestionCompletes { get; set; }
    }
}
