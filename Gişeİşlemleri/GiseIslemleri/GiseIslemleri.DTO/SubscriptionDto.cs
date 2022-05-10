using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DTO
{
    public class SubscriptionDto
    {
        public string CompanyName { get; set; }
        public decimal Deposit { get; set; } = 1000;
        public DateTime SubscriptionDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public int UserId { get; set; }
    }
}
