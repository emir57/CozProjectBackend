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
    public class EfRoleReadDal : EfReadRepository<Role>, IRoleReadDal
    {
        private readonly DbContext _context;
        public EfRoleReadDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsInRole(User user, Role role)
        {
            var userRole = await _context.Set<UserRole>().SingleOrDefaultAsync(x => x.UserId == user.Id && x.RoleId == role.Id);
            return userRole == null ? false : true;
        }
    }
}
