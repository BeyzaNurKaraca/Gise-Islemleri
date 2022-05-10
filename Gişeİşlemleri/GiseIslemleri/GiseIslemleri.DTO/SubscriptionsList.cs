using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DTO
{
    public class SubscriptionsList
    {
        public int SubscriptionsId { get; set; }
        public string CompanyName { get; set; }
        public string SubscriberName { get; set; }
        public decimal Deposit { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }
}
