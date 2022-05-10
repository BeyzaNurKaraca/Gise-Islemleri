using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DTO
{
    public class UserSubscriptions
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public ICollection<SubscriptionsList> UserSubscriptionList{ get; set; }
    }
}
