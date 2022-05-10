using GiseIslemleri.Core.Abstract;
using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Repository.Abstract
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        List<RoleList> GetRole();
    }
}
