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
    public interface IUserRepository : IBaseRepository<User>
    {
        List<UserList> GetUsers();
        List<UserRole> UpdateRole();
        List<UserSubscriptions> GetUserSubscriptions();
        List<UserSubscriptions> GetSubscriptionsOfUser(int id);
    }
}
