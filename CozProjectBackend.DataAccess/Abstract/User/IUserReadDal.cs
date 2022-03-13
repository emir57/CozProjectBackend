using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface IUserReadDal:IReadRepository<User>
    {
        IQueryable<Role> GetRoles(User user);
    }
}
