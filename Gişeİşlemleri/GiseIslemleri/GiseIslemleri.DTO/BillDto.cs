using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DTO
{
    public class BillDto
    {
        public decimal Debt { get; set; }
        public DateTime BillinDate { get; set; } = DateTime.Now;
        public DateTime DuaDate { get; set; } = DateTime.Now.AddMonths(2);
        public bool Status { get; set; }= false;
        public int SubscriptionId { get; set; }
    }
}
