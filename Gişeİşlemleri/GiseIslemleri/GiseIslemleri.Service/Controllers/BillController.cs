using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using GiseIslemleri.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiseIslemleri.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("List")]
        [AllowAnonymous]
        public IActionResult List()
        {
            var bills = _unitOfWork._billRepository.GetBillLists();
            if (bills.Count < 0)
            {
                return NotFound();
            }
            return Ok(bills);
        }

     
        [HttpGet("PaidBill/{id:int}")]
        [AllowAnonymous]
        public IActionResult PaidBillList(int id)
        {
            var bills = _unitOfWork._billRepository.GetSubscriptionPaidBillsLists(id);

            if (bills.Count()==0)
            {
                return NotFound();
            }
            return Ok(bills);
        }

        [HttpGet("UnPaidBillList/{id:int}")]
        [AllowAnonymous]
        public IActionResult UnPaidBillList(int id)
        {
            var bills = _unitOfWork._billRepository.GetSubscriptionUnPaidBillsLists(id);


            if (bills.Count() == 0)
            {
                return NotFound();
            }
            return  Ok(bills)  ;
        }

        [HttpGet("Find/{id:int}")]
        [AllowAnonymous]
        public IActionResult FinBill(int id)
        {
            Bill bill = _unitOfWork._billRepository.Find(id);
            if (bill != null)
            {
                return Ok(bill);
            }
            return NotFound();
        }

        [HttpPost("NewBill/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult CreateSubscription(int id, [FromBody] BillDto request)
        {
            Subscriptions subs = _unitOfWork._subscriptionRepository.Find(id);
            if (subs != null)
            {
                request.SubscriptionId = id;
                _unitOfWork._billRepository.Create(new Bill
                {
                    Debt = request.Debt,
                    BillingDate = request.BillinDate,
                    DuaTate = request.DuaDate,
                    Status = request.Status,
                    SubscriptionId = id
                });
                _unitOfWork.Save();
                return Ok(request);
            }
            return NotFound();
        }

        [HttpPut("PayBill/{id:int}")]
        [AllowAnonymous]
        public IActionResult PayBill(int id, decimal payment)
        {
            Bill bill = _unitOfWork._billRepository.Find(id);
            if (bill != null && bill.Debt <= payment && bill.Status == false)
            {
                bill.Status = true;
                payment -= bill.Debt;
                _unitOfWork._billRepository.Update(bill);
                _unitOfWork.Save();
                return Content($"Fatura ödeme başarılı. İade edilen tutar: { payment}. Fatura detayı: {bill}");
            }
            else if (bill != null && bill.Debt > payment)
            {
                return Content("Yeterli ödeme sağlanamamıştır");
            }
            else if (bill != null && bill.Status== true)
            {
                return Content("Faturaya ait borç bulunmamaktadır");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteBill/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult DeleteBill(int id)
        {
            Bill bill = _unitOfWork._billRepository.Find(id);
            if (bill != null)
            {
                _unitOfWork._billRepository.Delete(bill);
                _unitOfWork.Save();
                return Ok(bill);
            }
            return NotFound();
        }

    }
}
