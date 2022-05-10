using GiseIslemleri.Core.Abstract;
using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Repository.Abstract
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        List<BillList> GetBillLists();
        List<SubscriptionBills> GetSubscriptionPaidBillsLists(int id);
        List<SubscriptionBills> GetSubscriptionUnPaidBillsLists(int id);

    }
}
