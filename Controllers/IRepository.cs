using AuthAPI.Models;

namespace AuthAPI.Controllers
{
    public interface IRepository
    {
        public User GetUser(int Id);
    }
}
