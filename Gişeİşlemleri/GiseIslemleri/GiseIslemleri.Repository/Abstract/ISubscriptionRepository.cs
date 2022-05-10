using GiseIslemleri.Core.Abstract;
using GiseIslemleri.Core.Concrete;
using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Repository.Abstract
{
    public interface ISubscriptionRepository : IBaseRepository<Subscriptions>
    {
        List<SubscriptionsList> GetSubscriptionsLists();
        List<SubscriptionBills> GetSubscriptionBillsLists();
    }
}
