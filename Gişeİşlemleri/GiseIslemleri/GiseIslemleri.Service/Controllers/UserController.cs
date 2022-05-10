using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using GiseIslemleri.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiseIslemleri.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("List")]
        [Authorize(Roles = "3, 2")]
        public IActionResult List()
        {
            var users = _unitOfWork._userRepository.GetUsers();
            if (users.Count < 0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("Find/{id:int}")]
        [Authorize(Roles = "3, 2")]

        public IActionResult FindUser(int id)
        {
            User? user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("Update/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult UpdateUser(int id, [FromBody] Userlist model)
        {
            User user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {
                user.FirstName = model.Firstname;
                user.LastName = model.Surname;
                user.Email = model.UserEmail;
                _unitOfWork._userRepository.Update(user);
                _unitOfWork.Save();
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPut("UpdateUserRole/{id:int}")]
        [Authorize(Roles = "3")]

        public IActionResult UpdateUserRole(int id, [FromBody] UserRole model)
        {
            User user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {
                user.RoleId = model.UserRoleID;
                _unitOfWork._userRepository.Update(user);
                _unitOfWork.Save();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete("Delete/{id:int}")]
        [Authorize(Roles = "3")]

        public IActionResult DeleteUser(int id)
        {
            User user = _unitOfWork._userRepository.Find(id);
            if (user != null)
            {

                _unitOfWork._userRepository.Delete(user);
                _unitOfWork.Save();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet("AllSubscriptions")]
        [Authorize(Roles = "3, 2")]

        public IActionResult AllSubscriptions()
        {
            var subs = _unitOfWork._userRepository.GetUserSubscriptions();
            if (subs.Count>0)
            {
                return Ok( subs);

            }
            return NotFound();
        }
        [HttpGet("UserSubscriptions/{id:int}")]
        [Authorize(Roles = "3, 2")]
        public IActionResult UserSubscriptions(int id)
        {
            var subs = _unitOfWork._userRepository.GetSubscriptionsOfUser(id);
            if (subs.Count > 0)
            {
                return Ok(subs);

            }
            return NotFound();
        }
    }
}
