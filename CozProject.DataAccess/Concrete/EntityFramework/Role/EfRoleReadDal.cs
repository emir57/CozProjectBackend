using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfRoleReadDal : EfReadRepository<Role>, IRoleReadDal
{
    private readonly CozProjectDbContext _context;
    public EfRoleReadDal(CozProjectDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsInRole(int userId, int roleId)
    {
        var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
        return userRole == null ? false : true;
    }
}
