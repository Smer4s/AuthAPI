using AuthAPI.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AuthAPI.Controllers
{
    public class Repository
    {
        private readonly IServiceProvider _serviceProvider;

        public Repository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<User> Users()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        // Now you can use 'context' to interact with the database
            return context.Users.ToList();
        }
    }
}
