using AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Security.Cryptography;
using System.Text;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public bool GetUser([FromQuery] string login, string password)
        {
            if ((FormValidator.IsValid(login) && FormValidator.IsValid(password)) && DBValidator.IsValid(login, password))
            {
              //  PostToken(user);
                return true;
            }
            return false;
        }

        [HttpPost]
        public string PostToken(User user)
        {
            return TokenGenerator.GenerateToken(user.Login + user.Password);
        }
    }
}
