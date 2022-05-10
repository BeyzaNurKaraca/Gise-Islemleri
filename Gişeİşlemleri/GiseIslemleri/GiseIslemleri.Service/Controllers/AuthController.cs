using GiseIslemleri.DTO;
using GiseIslemleri.Entity;
using GiseIslemleri.Service.Authorization;
using GiseIslemleri.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiseIslemleri.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration, User user)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _user = user;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto userLogin)
        {
            User user = _unitOfWork._authRepository.Login(userLogin.Email, userLogin.Password);
            if (user != null)
            {
                
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);
                return Ok(new
                {
                    user = user,
                    token = token
                });
            }
            return NotFound();
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDto request)
        {

            _user.FirstName = request.FirstName;
            _user.LastName = request.LastName;
            _user.Email = request.Email;
            _user.RoleId = 1;
            _unitOfWork._authRepository.Register(_user, request.Password);
            return Ok(_user);
        }
    }
}
