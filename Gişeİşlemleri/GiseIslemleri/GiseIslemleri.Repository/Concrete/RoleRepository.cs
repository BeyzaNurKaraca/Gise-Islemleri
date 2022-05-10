using GiseIslemleri.Core.Concrete;
using GiseIslemleri.DAL;
using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using GiseIslemleri.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Repository.Concrete
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(GiseIslemleriContext context) : base(context)
        {
        }

        public List<RoleList> GetRole()
        {
            return Set().Select(x => new RoleList
            {
                Id = x.RoleId,
                RoleName = x.RoleName
            }).ToList();
        }
    }
}
