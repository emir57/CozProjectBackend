using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfUserReadDal : EfReadRepository<User>, IUserReadDal
{
    private readonly CozProjectDbContext _context;
    public EfUserReadDal(CozProjectDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Role> GetRoles(User user)
    {
        IQueryable<Role> roles = _context.Roles;
        IQueryable<UserRole> userRoles = _context.UserRoles;
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
