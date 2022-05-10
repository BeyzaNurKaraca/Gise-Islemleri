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
    public class SubscriptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("List")]
        [Authorize(Roles = "3, 2")]
        public IActionResult List()
        {
            var subs = _unitOfWork._subscriptionRepository.GetSubscriptionsLists();
            if (subs.Count < 0)
            {
                return NotFound();
            }
            return Ok(subs);
        }

        [HttpGet("Find/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult FindSubscription(int id)
        {
            Subscriptions subs = _unitOfWork._subscriptionRepository.Find(id);
            if (subs != null)
            {
                return Ok(subs);
            }
            return NotFound();
        }
        [HttpPost("NewSubscription/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult CreateSubscription(int id, [FromBody] SubscriptionDto request)
        {
            User user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {
                request.UserId = id;
                _unitOfWork._subscriptionRepository.Create(new Subscriptions
                {
                    CompanyName = request.CompanyName,
                    Deposit = request.Deposit,
                    SubscriptionDate = request.SubscriptionDate,
                    SubscriptionsStatus = request.Status,
                    UserId = request.UserId,


                });
                _unitOfWork.Save();
                return Ok(request);
            }
            return NotFound();
        }
        [HttpPut("UpdateSubscription/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult UpdateSubscription(int id, [FromBody] SubscriptionDto request)
        {
            Subscriptions subscriptions = _unitOfWork._subscriptionRepository.Find(id);
            if (subscriptions != null)
            {
                subscriptions.CompanyName = request.CompanyName;
                subscriptions.Deposit = request.Deposit;
                subscriptions.SubscriptionDate = request.SubscriptionDate;
                subscriptions.SubscriptionsStatus = request.Status;
                _unitOfWork._subscriptionRepository.Update(subscriptions);
                _unitOfWork.Save();
                return Ok(request);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("UpdateSubscriptionStatus/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult UpdateSubscriptionStatus(int id)
        {
            Subscriptions subscriptions = _unitOfWork._subscriptionRepository.Find(id);
            if (subscriptions != null)
            {
                var status = subscriptions.Bills.Where(x => x.SubscriptionId == subscriptions.SubscriptionsId && x.Status == false);
                if (status == null)
                {
                    subscriptions.Deposit = 0;
                    subscriptions.SubscriptionsStatus = false;
                    _unitOfWork._subscriptionRepository.Update(subscriptions);
                    _unitOfWork.Save();
                    return Content($"Kişinin aboneliği sonlandırılmış ve depozito ücreti iade edilecektir");
                }
                    return Content("Kişinin Ödenmemiş Fatraları vardır");
            }
            return NotFound();
        }
        [HttpDelete("DeleteSubscription/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult DeleteSubscription(int id)
        {
            Subscriptions subscriptions = _unitOfWork._subscriptionRepository.Find(id);
            if (subscriptions != null)
            {
                var status = subscriptions.Bills.Where(x => x.SubscriptionId == subscriptions.SubscriptionsId && x.Status == true);
                if (status.Count() > 0)
                {
                    subscriptions.Deposit = 0;
                    subscriptions.SubscriptionsStatus = false;
                    _unitOfWork._subscriptionRepository.Delete(subscriptions);
                    _unitOfWork.Save();
                    return Content($"Kişinin abonelik kayıtları silinmiştir.");
                }
                return Content("Kişinin Ödenmemiş Fatraları vardır");
            }
            return NotFound();
        }

    }
}
