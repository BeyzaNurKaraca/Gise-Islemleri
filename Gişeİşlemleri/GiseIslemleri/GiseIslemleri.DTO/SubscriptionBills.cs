using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DTO
{
    public class SubscriptionBills
    {
        public int SubscriptionsId { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public ICollection<BillList> SubscriptionBillList{ get; set; }
    }
}
