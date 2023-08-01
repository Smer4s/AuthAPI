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
        public bool GetUser([FromQuery]User user)
        {
            if (Validator.IsValid(user.Password) && Validator.IsValid(user.Login))
            {
                PostToken(user);
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
