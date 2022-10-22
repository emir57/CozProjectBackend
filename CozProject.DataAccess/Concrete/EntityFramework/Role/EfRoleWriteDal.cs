﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Concrete.EntityFramework
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

        public async Task<UserRole> GetUserRoleById(int userId, int roleId)
        {
            return await _context.Set<UserRole>().SingleOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
        }

        public void RemoveUserRole(UserRole userRole)
        {

            _context.Set<UserRole>().Remove(userRole);
        }
    }
}