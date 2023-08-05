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
        public string GetUser([FromQuery] string mail, string password)
        {
            if ((FormValidator.IsValid(mail, password) && DBValidator.IsValid(mail, password)))
            {
                return TokenGenerator.GenerateToken(mail + password);
            }
            return "";
        }

        [HttpPost]
        public string PostToken(User user)
        {
            return TokenGenerator.GenerateToken(user.Email + user.Password);
        }
    }
}
