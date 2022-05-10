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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GiseIslemleriContext context) : base(context)
        {
        }

        public List<UserSubscriptions> GetSubscriptionsOfUser(int id)
        {
            User user = Set().Find(id);
            if (user != null)
            {
                return Set().Select(x => new UserSubscriptions
                {
                    UserId = x.UserId,
                    FullName = x.FirstName + " " + x.LastName,
                    UserSubscriptionList = x.Subscriptions.Select(y => new SubscriptionsList
                    {
                        SubscriptionsId = y.SubscriptionsId,
                        CompanyName = y.CompanyName,
                        SubscriberName = y.User.FirstName + " " + x.LastName,
                        Deposit = y.Deposit,
                        SubscriptionDate = y.SubscriptionDate,

                    }).ToList()
                }).Where(x => x.UserId == id).ToList();
            }
            return null;
        }

        public List<UserList> GetUsers()
        {
            return Set().Select(x => new UserList
            {
                Id = x.UserId,
                UserFullName = x.FirstName + " " + x.LastName,
                UserEmail = x.Email,
                UserRole = x.Role.RoleName
            }).ToList();
        }

        public List<UserSubscriptions> GetUserSubscriptions()
        {
            return Set().Select(x => new UserSubscriptions
            {
                UserId = x.UserId,
                FullName = x.FirstName + " " + x.LastName,
                UserSubscriptionList = x.Subscriptions.Select(y => new SubscriptionsList
                {
                    SubscriptionsId = y.SubscriptionsId,
                    CompanyName = y.CompanyName,
                    SubscriberName= y.User.FirstName + " " + x.LastName,
                    Deposit = y.Deposit,
                    SubscriptionDate = y.SubscriptionDate,

                }).ToList()
            }).ToList();
        }

        public List<UserRole> UpdateRole()
        {
            return Set().Select(x => new UserRole
            {
                UserRoleID = x.RoleId
            }).ToList();
        }
    }
}
