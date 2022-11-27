using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfRoleWriteDal : EfWriteRepository<Role>, IRoleWriteDal
    {
        private readonly CozProjectDbContext _context;
        public EfRoleWriteDal(CozProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddUserRoleAsync(int userId, int roleId)
        {
            await _context.UserRoles.AddAsync(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
        }

        public async Task<UserRole> GetUserRoleById(int userId, int roleId)
        {
            return await _context.UserRoles.SingleOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
        }

        public void RemoveUserRole(UserRole userRole)
        {

            _context.UserRoles.Remove(userRole);
        }
    }
}
