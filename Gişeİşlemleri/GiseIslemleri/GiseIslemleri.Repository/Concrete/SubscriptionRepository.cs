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
    public class SubscriptionRepository : BaseRepository<Subscriptions>, ISubscriptionRepository
    {
        public SubscriptionRepository(GiseIslemleriContext context) : base(context)
        {
        }

        public List<SubscriptionBills> GetSubscriptionBillsLists()
        {
           
            return Set().Select(s => new SubscriptionBills { 
                SubscriptionsId = s.SubscriptionsId,
                CompanyName = s.CompanyName,
                UserName=s.User.FirstName+" "+s.User.LastName,
                SubscriptionBillList = s.Bills.Select(b=> new BillList
                {
                    BillId = b.BillId,
                    SubscriberName = b.Subscriptions.User.FirstName+" "+ b.Subscriptions.User.LastName,
                    Debt=b.Debt,
                    BillingDate = b.BillingDate,
                    DuaTate=b.DuaTate,
                    Status  = b.Status
                }).ToList()
                
            }).ToList();
        }

        public List<SubscriptionsList> GetSubscriptionsLists()
        {
            return Set().Select(s => new SubscriptionsList
            {
                SubscriptionsId = s.SubscriptionsId,
                CompanyName = s.CompanyName,
                SubscriberName = s.User.FirstName + " " + s.User.LastName,
                Deposit = s.Deposit,
                SubscriptionDate = s.SubscriptionDate,

            }).ToList();
        }
    }
}
