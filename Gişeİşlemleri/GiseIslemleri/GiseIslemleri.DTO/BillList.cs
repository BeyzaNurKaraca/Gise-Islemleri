using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DTO
{
    public class BillList
    {
        public int BillId { get; set; }
        public string SubscriberName { get; set; }
        public decimal Debt { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime DuaTate { get; set; }
        public bool Status { get; set; } = false;
    }
}
