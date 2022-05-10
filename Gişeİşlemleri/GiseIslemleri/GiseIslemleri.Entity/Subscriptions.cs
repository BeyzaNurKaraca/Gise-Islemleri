using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Entity
{
    public class Subscriptions
    {
        public Subscriptions()
        {
            Bills = new HashSet<Bill>();
        }
        public int SubscriptionsId { get; set; }
        public string CompanyName { get; set; }
        public decimal Deposit { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public bool SubscriptionsStatus { get; set; } = true;
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Bill> Bills { get; set; }

    }
}
