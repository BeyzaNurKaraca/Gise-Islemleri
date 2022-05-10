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
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(GiseIslemleriContext context) : base(context)
        {
        }

        public List<BillList> GetBillLists()
        {
           return Set().Select(b => new BillList
           {
               BillId = b.BillId,
               SubscriberName  = b.Subscriptions.User.FirstName+" " + b.Subscriptions.User.LastName,
               BillingDate = b.BillingDate,
               Debt=b.Debt,
               DuaTate=b.DuaTate,
               Status= b.Status
           }).ToList();
        }
        public List<SubscriptionBills> GetSubscriptionPaidBillsLists(int id)
        {

            return Set().Select(s => new SubscriptionBills
            {
                SubscriptionsId =s.SubscriptionId,
                CompanyName = s.Subscriptions.CompanyName,
                SubscriptionBillList = Set().Select(b => new BillList
                {
                    BillId = b.BillId,
                    SubscriberName = b.Subscriptions.User.FirstName + " " + b.Subscriptions.User.LastName,
                    Debt = b.Debt,
                    BillingDate = b.BillingDate,
                    DuaTate = b.DuaTate,
                    Status = b.Status
                }).Where(b=> b.Status==true).ToList()
            }).Where(x => x.SubscriptionsId == id ).ToList();
        }
        public List<SubscriptionBills> GetSubscriptionUnPaidBillsLists(int id)
        {

            return Set().Select(s => new SubscriptionBills
            {
                SubscriptionsId =s.SubscriptionId,
                CompanyName = s.Subscriptions.CompanyName,
                SubscriptionBillList = Set().Select(b => new BillList
                {
                    BillId = b.BillId,
                    SubscriberName = b.Subscriptions.User.FirstName + " " + b.Subscriptions.User.LastName,
                    Debt = b.Debt,
                    BillingDate = b.BillingDate,
                    DuaTate = b.DuaTate,
                    Status = b.Status
                }).Where(b=> b.Status!=true).ToList()
            }).Where(x => x.SubscriptionsId == id ).ToList();
        }
    }
}
