using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfRoleReadDal : EfReadRepository<Role>, IRoleReadDal
    {
        private readonly DbContext _context;
        public EfRoleReadDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsInRole(int userId, int roleId)
        {
            var userRole = await _context.Set<UserRole>().FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
            return userRole == null ? false : true;
        }
    }
}
