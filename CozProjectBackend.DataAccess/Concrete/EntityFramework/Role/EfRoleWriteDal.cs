using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProjectBackend.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfRoleWriteDal : EfWriteRepository<Role>, IRoleWriteDal
    {
        private DbContext _context;
        public EfRoleWriteDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddUserRoleAsync(int userId, int roleId)
        {
            await _context.Set<UserRole>().AddAsync(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
        }
        public async Task RemoveUserRoleAsync(int userId, int roleId)
        {
            var userRole = await _context.Set<UserRole>().SingleOrDefaultAsync(x=>x.UserId==userId && x.RoleId == roleId);
            _context.Set<UserRole>().Remove(userRole);
        }
    }
}
