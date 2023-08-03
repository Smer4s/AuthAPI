using AuthAPI.Models;
using System.Text.RegularExpressions;
using AuthAPI;

namespace AuthAPI.Controllers
{
    public static class DBValidator
    {
        private static Repository _repository;

        public static void Initialize(Repository repository)
        {
            _repository = repository;
        }

        public static bool IsValid(string login, string password)
        {
            var users = _repository.Users();

            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                    return true;
            }

            return false;
        }
    }
}
