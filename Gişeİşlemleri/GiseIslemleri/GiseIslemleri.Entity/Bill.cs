using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Entity
{
    public class Bill
    {
        public int BillId { get; set; }
        public decimal Debt { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime DuaTate { get; set; }
        public bool Status { get; set; } = false;
        public int SubscriptionId { get; set; }
        public Subscriptions Subscriptions { get; set; }

    }
}
