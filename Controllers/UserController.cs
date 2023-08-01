using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public ICollection<User> GetUser(User user)
        {
            return new List<User>()
        {
            user
        };
        }
    }
}
