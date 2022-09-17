using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserReadDal : EfReadRepository<User>, IUserReadDal
    {
        private DbContext _context;
        public EfUserReadDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Role> GetRoles(User user)
        {
            IQueryable<Role> roles = _context.Set<Role>();
            IQueryable<UserRole> userRoles = _context.Set<UserRole>();
            IQueryable<Role> result = from r in roles
                         join ur in userRoles
                         on r.Id equals ur.RoleId
                         where ur.UserId == user.Id
                         select new Role
                         {
                             Id = r.Id,
                             Name = r.Name
                         };
            return result;
        }
    }
}
